using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
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
    public delegate void BatchGeneratorEventHandler(string message);
    public event BatchGeneratorEventHandler OnProcessUpdate;

    private readonly string _cacheFileName = "x12Segments.json";
    private IBrowser _browser;
    public BatchGenerator()
    {
        var fetcher = new BrowserFetcher();
        var result = fetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision).Result;

        _browser = Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
        }).Result;

    }

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
            OnProcessUpdate?.Invoke($"Finished loading all versionAndSegments from cache");
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
        OnProcessUpdate?.Invoke($"storing all versionAndSegments to cache");
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
        var codeGenerator = new CodeGenerator();
        var testGenerator = new TestGenerator();
        var parser = new CodeParser();

        var codeBasePath = projectBasePath + @"Eddy.x12\Models";
        var testBasePath = projectBasePath + @"Eddy.Tests.x12\Models";
        var ignored = new List<string>() {"ADJ", "B10"}; //ones that are not generating very well

        //make sure directories exist for all versions
        foreach (var versionAndSegment in versionAndSegments)
        {
            var codeFolder = codeBasePath + "\\v" + versionAndSegment.Key;
            var testFolder = testBasePath + "\\v" + versionAndSegment.Key;
            if (!Directory.Exists(codeFolder))
                Directory.CreateDirectory(codeFolder);

            if (!Directory.Exists(testFolder))
                Directory.CreateDirectory(testFolder);            
        }
        OnProcessUpdate?.Invoke($"Code/Test folders created");

        foreach (var versionAndSegment in versionAndSegments) //start at 3010 and go up
        {

            var version = versionAndSegment.Key; //key is the string version name e.g. 04010
            OnProcessUpdate?.Invoke($"Processing version {version}");

            //var testPath = projectBasePath + @"Eddy.Tests.x12\Models";
            foreach (var segmentData in versionAndSegment.Value)
            {

                if (ignored.Contains(segmentData.Type)) //this one is being a nightmare
                {
                    continue;
                }

                var codePath = codeBasePath + "\\v" + versionAndSegment.Key + "\\" + segmentData.Name + ".cs";
                var testPath = testBasePath + "\\v" + versionAndSegment.Key + "\\" + segmentData.Type + "Tests.cs";

                if (File.Exists(codePath)) //don't regen if already exists
                    continue;

                var filesToWrite = new Dictionary<string, string>(); //path and code

                OnProcessUpdate?.Invoke($"Processing segment {version}-{segmentData.Type}");
                var segmentsInVersions = FindSegmentInAllVersions(segmentData.Type, versionAndSegments);
                OnProcessUpdate?.Invoke($"Segment also exists in the following versions: " + string.Join(", ", segmentsInVersions.Keys));
                var concurrentParsedResults = new ConcurrentDictionary<string, ParsedSegment>();

                //second parameter: new ParallelOptions { MaxDegreeOfParallelism = 4 }
                await Parallel.ForEachAsync(segmentsInVersions, async (otherSegment, token) =>
                {
                    OnProcessUpdate?.Invoke($"Parsing {otherSegment.Key}-{otherSegment.Value.Type}");
                    var rawPageData = await GetPage(otherSegment.Value.Url);
                    //wrap the node in an element so that there is only one root element
                    var wrappedNode = HtmlNode.CreateNode("<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + rawPageData + Environment.NewLine + "</div>");
                    concurrentParsedResults.TryAdd(otherSegment.Key, parser.Parse(wrappedNode, ParseType.x12Segment));
                } );
                
                // foreach (var otherSegment in segmentsInVersions)
                // {
                //         OnProcessUpdate?.Invoke($"Parsing {otherSegment.Key}-{otherSegment.Value.Type}");
                //         var rawPageData = await GetPage(otherSegment.Value.Url);
                //         //wrap the node in an element so that there is only one root element
                //         var wrappedNode = HtmlNode.CreateNode("<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + rawPageData + Environment.NewLine + "</div>");
                //         parsedByVersion.TryAdd(otherSegment.Key, parser.Parse(wrappedNode, ParseType.x12Segment));
                //     
                // }

                //write out the base item which would be the first item in the collection
                var parsedByVersion = concurrentParsedResults.OrderBy(kvp=>kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);


                var lastCode = parsedByVersion.First();

                var generatedCode = codeGenerator.GenerateCode(lastCode.Value, ParseType.x12Segment, version);
                var generatedTest = testGenerator.GenerateTests(lastCode.Value, ParseType.x12Segment, version);

                if (!File.Exists(codePath))
                    filesToWrite.Add(codePath, generatedCode);
                if (!File.Exists(testPath))
                    filesToWrite.Add(testPath, generatedTest);

                OnProcessUpdate?.Invoke($"Initial code generated");

                foreach (var parsedSegment in parsedByVersion.Skip(1)) //skip the first record as we just wrote it out above as our base item
                    if (lastCode.Value.Equals(parsedSegment.Value)) //no change between versions
                    {
                        codePath = projectBasePath + @"Eddy.x12\Models\v" + parsedSegment.Key + "\\" + segmentData.Name + ".cs";
                        var generatedInheritanceCode = codeGenerator.GenerateInheritanceCodeFrom(lastCode.Value, parsedSegment.Key, lastCode.Key);
                        if (!File.Exists(codePath))
                            filesToWrite.Add(codePath, generatedInheritanceCode);
                        lastCode = parsedSegment;
                        //no test required

                        OnProcessUpdate?.Invoke($"Inheritance code generated for {parsedSegment.Key}-{segmentData.Type}");
                    }
                    else
                    {
                        OnProcessUpdate?.Invoke($"Code Varied. Restarting inheritance tree {parsedSegment.Key}-{segmentData.Type}");
                        codePath = projectBasePath + @"Eddy.x12\Models\v" + parsedSegment.Key + "\\" + segmentData.Name + ".cs";
                        testPath = testBasePath + "\\v" + parsedSegment.Key + "\\" + segmentData.Type + "Tests.cs";
                        generatedCode = codeGenerator.GenerateCode(parsedSegment.Value, ParseType.x12Segment, parsedSegment.Key);
                        generatedTest = testGenerator.GenerateTests(parsedSegment.Value, ParseType.x12Segment, parsedSegment.Key);
                        if (!File.Exists(codePath))
                            filesToWrite.Add(codePath, generatedCode);
                        if (!File.Exists(testPath))
                            filesToWrite.Add(testPath, generatedTest);
                        lastCode = parsedSegment;
                    }

                foreach (var fileToWrite in filesToWrite)
                {
                    File.WriteAllText(fileToWrite.Key, fileToWrite.Value);
                }

                counter++;
                OnProcessUpdate?.Invoke($"Batch {counter}/{batchCount} Completed");
                if (counter >= batchCount)
                {
                    await _browser.CloseAsync();
                    return;
                }
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
        var page = await _browser.NewPageAsync().ConfigureAwait(false);
        await page.GoToAsync(url, 30_000, new[] { WaitUntilNavigation.Networkidle0 }).ConfigureAwait(false); 

        //await page.WaitForTimeoutAsync(2000);
        var select = await page.QuerySelectorAsync("main");
        var content = await page.EvaluateFunctionAsync<string>("e => e.innerHTML", select);
       

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