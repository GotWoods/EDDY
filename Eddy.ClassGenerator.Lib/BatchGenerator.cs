﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PuppeteerSharp;

namespace Eddy.ClassGenerator.Lib;

public class SegmentData
{
    public string Type { get; set; } //e.g. ACD
    public string Name { get; set; } //e.g. Account Description
    public string Url { get; set; } //e.g. https://www.stedi.com/edi/x12-008020/segment/ACD
}

public class BatchGenerator
{
    private readonly string _cacheFileName = "x12Segments.json";

    private readonly string[] _x12Versions =
    {
        "3010", "3020", "3030", "3040", "3050", "3060", "3070",
        "4010", "4020", "4030", "4040", "4050", "4060",
        "5010", "5020", "5030", "5040", "5050",
        "6010", "6020", "6030", "6040", "6050",
        "7010", "7020", "7030", "7040", "7050", "7060",
        "8010", "8020", "8030", "8040"
    };

    private Dictionary<string, List<SegmentData>> LoadDictionaryFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            var jsonData = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<Dictionary<string, List<SegmentData>>>(jsonData);
        }

        return null;
    }

    private void SaveDictionaryToFile(Dictionary<string, List<SegmentData>> data, string filePath)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        var jsonData = JsonSerializer.Serialize(data, options);
        File.WriteAllText(filePath, jsonData);
    }

    private async Task<Dictionary<string, List<SegmentData>>> LoadSegmentsAndVersionInfo(bool flushCache)
    {
        var versionAndSegments = LoadDictionaryFromFile(_cacheFileName);
        if (versionAndSegments == null || flushCache)
        {
            versionAndSegments = new Dictionary<string, List<SegmentData>>();
            foreach (var version in _x12Versions)
            {
                var page = await GetPage("https://www.stedi.com/edi/x12-00" + version + "/segment");
                var pageText = "<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + page + Environment.NewLine + "</div>";
                var newNode = HtmlNode.CreateNode(pageText);
                var segments = newNode.SelectNodes("/div/div/ul/li");
                var segmentTypesAndUris = new List<SegmentData>();

                foreach (var item in segments)
                {
                    var link = item.SelectSingleNode("a");
                    var data = new SegmentData();
                    data.Type = link.SelectSingleNode("h2/span").InnerText;
                    data.Name = CodeGenerator.GetCodeClassName(data.Type, link.SelectSingleNode("h2").ChildNodes[1].InnerText);
                    data.Url = "https://www.stedi.com" + link.GetAttributeValue("href", "");
                    segmentTypesAndUris.Add(data);
                }

                versionAndSegments.Add(version, segmentTypesAndUris);
            }

            SaveDictionaryToFile(versionAndSegments, _cacheFileName);
        }

        return versionAndSegments;
    }

    public async Task Start(string projectBasePath, int batchCount)
    {
        //A1 only exists between 3010 and 3060
        var versionAndSegments = await LoadSegmentsAndVersionInfo(false);
        var counter = 0;
        var generator = new CodeGenerator();

        var codeBasePath = projectBasePath + @"Eddy.x12\Models";
        var testBasePath = projectBasePath + @"Eddy.x12.Tests\Models";

        //make sure directories exist for all versions
        foreach (var versionAndSegment in versionAndSegments)
        {
            var codeFolder = codeBasePath + "\\v" + versionAndSegment.Key;
            var testFolder = testBasePath + "\\v" + versionAndSegments.Keys;
            if (!Directory.Exists(codeFolder))
                Directory.CreateDirectory(codeFolder);

            if (!Directory.Exists(testFolder))
                Directory.CreateDirectory(testFolder);
        }

        foreach (var versionAndSegment in versionAndSegments) //start at 3010 and go up
        {
            var version = versionAndSegment.Key; //key is the string version name e.g. 04010


            //var testPath = projectBasePath + @"Eddy.Tests.x12\Models";
            foreach (var segmentData in versionAndSegment.Value)
            {
                var segmentsInVersions = FindSegmentInAllVersions(segmentData.Type, versionAndSegments);

                var parsedByVersion = new Dictionary<string, ParsedSegment>();
                foreach (var otherSegment in segmentsInVersions)
                {
                    var rawPageData = await GetPage(segmentData.Url);
                    //wrap the node in an element so that there is only one root element
                    var wrappedNode = HtmlNode.CreateNode("<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + rawPageData + Environment.NewLine + "</div>");
                    parsedByVersion.Add(otherSegment.Key, generator.Parse(wrappedNode, ParseType.x12Segment));
                }

                //write out the base item which would be the first item in the collection
                var lastCode = parsedByVersion.First();
                var generatedCode = generator.GenerateCode(lastCode.Value, ParseType.x12Segment, version);
                var codePath = codeBasePath + "\\v" + versionAndSegment.Key + "\\" + generatedCode.codeClassName + ".cs";
                var testPath = testBasePath + "\\v" + versionAndSegment.Key + "\\" + segmentData.Type + "Tests.cs";
                if (!File.Exists(codePath))
                    await File.WriteAllTextAsync(codePath, generatedCode.Code);
                if (!File.Exists(testPath))
                    await File.WriteAllTextAsync(testPath, generatedCode.Test);


                foreach (var parsedSegment in parsedByVersion.Skip(1)) //skip the first record as we just wrote it out above as our base item
                    if (lastCode.Value.Equals(parsedSegment.Value)) //no change between versions
                    {
                        codePath = projectBasePath + @"Eddy.x12\Models\v" + parsedSegment.Key + "\\" + generatedCode.codeClassName + ".cs";
                        var generatedInheritanceCode = generator.GenerateInheritanceCodeFrom(lastCode.Value, parsedSegment.Key, lastCode.Key);
                        if (!File.Exists(codePath))
                            await File.WriteAllTextAsync(codePath, generatedInheritanceCode);
                        lastCode = parsedSegment;
                        //no test required
                    }
                    else
                    {
                        throw new NotSupportedException("No idea what to do now!");
                    }
                counter++;
                if (counter >= batchCount)
                    return;
            }
        }
    }

    private Dictionary<string, SegmentData> FindSegmentInAllVersions(string segmentType, Dictionary<string, List<SegmentData>> versionAndSegments)
    {
        var results = new Dictionary<string, SegmentData>();

        foreach (var versionAndSegment in versionAndSegments)
        {
            var found = versionAndSegment.Value.FirstOrDefault(x => x.Type == segmentType);
            if (found != null) results.Add(versionAndSegment.Key, found);
        }

        return results;
    }


    //foreach segment
    //generate model for segment
    //check for previous versions
    //if no previous version, then it is brand new
    //if there is a previous version:
    //  if there is no difference, then simple inheritance to blank class from previous
    //  if there is a difference, then find diffs
    //     create inherited class based on the diffs


    private async Task<string> GetPage(string url)
    {
        var fetcher = new BrowserFetcher();
        var result = await fetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);

        var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
        });

        var page = await browser.NewPageAsync();
        await page.GoToAsync(url, WaitUntilNavigation.Networkidle0);

        //await page.WaitForTimeoutAsync(2000);
        var select = await page.QuerySelectorAsync("main");
        var content = await page.EvaluateFunctionAsync<string>("e => e.innerHTML", select);
        await browser.CloseAsync();

        return content;
    }

    // private List<string> GetExistingFiles()
    // {
    //     var path = projectBasePath + @"Eddy.x12\Models";
    //     var results = new List<string>();
    //     foreach (var file in Directory.GetFiles(path))
    //         if (file.IndexOf("_") > -1)
    //         {
    //             var filename = file.Substring(0, file.IndexOf("_"));
    //             filename = filename.Substring(file.LastIndexOf('\\') + 1);
    //             results.Add(filename);
    //         }
    //
    //     return results;
    // }
}