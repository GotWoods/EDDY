using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Eddy.Core.Attributes;
using HtmlAgilityPack;
using PuppeteerSharp;
using System.Text.Json;

namespace Eddy.ClassGenerator.Lib;

public class SegmentData
{
    public string Type { get; set; } //e.g. ACD
    public string Name { get; set; } //e.g. Account Description
    public string Url { get; set; } //e.g. https://www.stedi.com/edi/x12-008020/segment/ACD
}

public class BatchGenerator
{
    private string[] _x12Versions = new string[]
    {
        "3010", "3020", "3030", "3040", "3050", "3060", "3070",
        "4010", "4020", "4030", "4040", "4050", "4060",
        "5010", "5020", "5030", "5040", "5050",
        "6010", "6020", "6030", "6040", "6050",
        "7010", "7020", "7030", "7040", "7050", "7060",
        "8010", "8020", "8030", "8040"
    };
    private string _cacheFileName = "x12Segments.json";
    private Dictionary<string, List<SegmentData>> LoadDictionaryFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            string jsonData = File.ReadAllText(filePath);
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
        string jsonData = JsonSerializer.Serialize(data, options);
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
        var versionAndSegments = await LoadSegmentsAndVersionInfo(false);
        var counter = 0;
        foreach (var versionAndSegment in versionAndSegments)
        {
            var modelPath = projectBasePath + @"Eddy.x12\Models\v" + versionAndSegment.Key; //key is the string version name e.g. 04010
            if (!Directory.Exists(modelPath))
                Directory.CreateDirectory(modelPath);

            //var testPath = projectBasePath + @"Eddy.Tests.x12\Models";
            foreach (var segmentAndUrl in versionAndSegment.Value)
            {
                var outputFileName = modelPath + "\\" + segmentAndUrl.Name + ".cs";
                if (!File.Exists(outputFileName))
                {
                    var s = await GetPage(segmentAndUrl.Url);
                    var text = "<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + s + Environment.NewLine + "</div>";
                    var newNode2 = HtmlNode.CreateNode(text);
                    var generator = new CodeGenerator();
                    var results = generator.ParseData(newNode2, ParseType.x12Segment);
                    counter++;

                    File.WriteAllText(outputFileName, results.Code);
                    //File.WriteAllText(testPath + "\\" + type + "Tests.cs", results.Test);

                    if (counter >= batchCount)
                        return;
                }
            }
        }
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