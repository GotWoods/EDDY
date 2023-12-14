using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using HtmlAgilityPack;
//using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using PuppeteerSharp;

namespace Eddy.ClassGenerator.Lib;

public class TransactionSet
{
    public string TransactionNumber { get; set; } //e.g. 990
    public string Name { get; set; } //e.g. ResponseToLoadTEnder
    public string Url { get; set; } //e.g. https://www.stedi.com/edi/x12-008020/segment/ACD
}

public class TransactionSetBatchGenerator
{
    public delegate void BatchGeneratorEventHandler(string message);

    private readonly IBrowser _browser;
    private readonly string _cacheFileName = "x12TransactionSets.json";

    private readonly string[] _transactionSets =
    {
        "CommunicationsAndControls", "Finance", "Transportation", "SupplyChain"
    };

    private readonly string[] _x12Versions =
    {
        "3010"
        , "3020", "3030", "3040", "3050", "3060", "3070",
        "4010", "4020", "4030", "4040", "4050", "4060",
        "5010", "5020", "5030", "5040", "5050",
        "6010", "6020", "6030", "6040", "6050",
        "7010", "7020", "7030", "7040", "7050", "7060",
        "8010", "8020", "8030", "8040"
    };

    public TransactionSetBatchGenerator()
    {
        var fetcher = new BrowserFetcher();
        var result = fetcher.DownloadAsync(BrowserTag.Stable).Result;

        _browser = Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
        }).Result;
    }

    public event BatchGeneratorEventHandler OnProcessUpdate;

    private Dictionary<string, List<SegmentData>> LoadDictionaryFromFile(string filePath)
    {
        if (File.Exists(filePath))
        {
            var jsonData = File.ReadAllText(filePath);
            OnProcessUpdate?.Invoke("Finished loading all versionAndSegments from cache");
            return JsonSerializer.Deserialize<Dictionary<string, List<SegmentData>>>(jsonData);
        }

        return null;
    }

    private async Task<Dictionary<string, List<SegmentData>>> LoadSegmentsAndVersionInfo(bool flushCache)
    {
        var versionAndTransactionSets = LoadDictionaryFromFile(_cacheFileName);
        if (versionAndTransactionSets == null || flushCache)
        {
        versionAndTransactionSets = new Dictionary<string, List<SegmentData>>();
        foreach (var version in _x12Versions)
        {
            OnProcessUpdate?.Invoke("Getting transaction sets for version " + version);
            var transactionSetPage = await GetPage("https://www.stedi.com/edi/x12-00" + version + "/transaction-set");
            var transactionPageText = "<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + transactionSetPage + Environment.NewLine + "</div>";
            var transactionNodes = HtmlNode.CreateNode(transactionPageText);
            var industryTypes = transactionNodes.SelectNodes("/div/div/div[2]/div/details");

            var segments = new List<SegmentData>();

            foreach (var industryTypeSection in industryTypes)
            {
                //var industryGroup = new IndustryGroup() { Name =  };
                //OnProcessUpdate?.Invoke(industryGroup.Name);
                var transactionSets = industryTypeSection.SelectNodes("ul/li");
                foreach (var transactionSet in transactionSets)
                {
                    var link = transactionSet.SelectSingleNode("a");
                    var data = new SegmentData();
                    data.Type = link.SelectSingleNode("h2/span").InnerText;
                    data.Name = CodeGenerator.GetCodeClassName(data.Type, link.SelectSingleNode("h2").ChildNodes[1].InnerText);
                    data.Url = "https://www.stedi.com" + link.GetAttributeValue("href", "");
                    data.Industry = industryTypeSection.SelectSingleNode("summary/div/div").InnerText;
                    //    industryGroup.TransactionSets.Add(data);
                    segments.Add(data);
                }

                //industryGroupsForThisVersion.Add(industryGroup);
            }

            versionAndTransactionSets.Add(version, segments);
        }

        SaveDictionaryToFile(versionAndTransactionSets, _cacheFileName);
        }


        return versionAndTransactionSets;
    }

    private void SaveDictionaryToFile(Dictionary<string, List<SegmentData>> data, string filePath)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        OnProcessUpdate?.Invoke("storing all versionAndTransactionSets to cache");
        var jsonData = JsonSerializer.Serialize(data, options);
        File.WriteAllText(filePath, jsonData);
    }

    private async Task<string> GetPage(string url)
    {
        var page = await _browser.NewPageAsync().ConfigureAwait(false);
        await page.GoToAsync(url, 30_000, new[] { WaitUntilNavigation.Networkidle0 }).ConfigureAwait(false);

        //await page.WaitForTimeoutAsync(2000);
        var select = await page.QuerySelectorAsync("main");
        var content = await page.EvaluateFunctionAsync<string>("e => e.innerHTML", select);


        return content;
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



    public async Task Start(string projectBasePath, int batchCount)
    {
        var parser = new TransactionSetParser();
        var counter = 0;
        var versionAndSegments = await LoadSegmentsAndVersionInfo(false);
        var codeGenerator = new TransactionSetCodeGenerator();

        var ignored = new List<string>()
        {
            "104",
            "110",
            "114",
            "204",
            "210",
            "213",
            "217",
            "858",
            "859",
            "997", //there is an extra div here that explains a 997
        }; //ones that are not generating very well

        foreach (var versionAndSegment in versionAndSegments)
        {
            //var transportation = versionAndSegment.Value.FirstOrDefault(x => x.Name == "Transportation");
            var versionFolder = projectBasePath + "\\Eddy.x12.DomainModels.Transportation\\v" + versionAndSegment.Key;
            // var testFolder = testBasePath + "\\v" + versionAndSegment.Key;
            if (!Directory.Exists(versionFolder))
                Directory.CreateDirectory(versionFolder);

            //
            // if (!Directory.Exists(testFolder))
            //     Directory.CreateDirectory(testFolder);
            //


            var transportationSegments = versionAndSegment.Value.Where(x => x.Industry == "Transportation");

            foreach (var transportationTransactionSet in transportationSegments)
            {
                var segmentFolder = projectBasePath + "\\Eddy.x12.DomainModels.Transportation\\v" + versionAndSegment.Key + "\\" + transportationTransactionSet.Type;
                if (!Directory.Exists(segmentFolder))
                    Directory.CreateDirectory(segmentFolder);

                //OnProcessUpdate?.Invoke($"Processing segment {versionAndSegment.Key}-{transportationTransactionSet.Type}");
                var segmentsInVersions = FindSegmentInAllVersions(transportationTransactionSet.Type, versionAndSegments);
                //TODO: Should we check to make sure the industries match? What if the type hops from one industry to another?

                foreach (var segmentsInVersion in segmentsInVersions)
                {
                    if (segmentsInVersion.Value.Industry != "Transportation")
                    {
                        OnProcessUpdate?.Invoke($"Segment {versionAndSegment.Key} moved types");
                        throw new Exception($"Expected {segmentsInVersion.Value.Type} to be in Transportation but was found in {segmentsInVersion.Value.Industry}");
                    }
                }

                //OnProcessUpdate?.Invoke($"Segment also exists in the following versions: " + string.Join(", ", segmentsInVersions.Keys));
                
            }
        }
        OnProcessUpdate?.Invoke("Code/Test folders created");


        foreach (var versionAndSegment in versionAndSegments) //start at 3010 and go up
        {
            var transportationSegments = versionAndSegment.Value.Where(x => x.Industry == "Transportation");
            var version = versionAndSegment.Key; //key is the string version name e.g. 04010
            OnProcessUpdate?.Invoke($"Processing version {version}");

            //var testPath = projectBasePath + @"Eddy.Tests.x12\Models";
            foreach (var segmentData in transportationSegments)
            {
                if (ignored.Contains(segmentData.Type))
                {
                    continue;
                }

                // if (ignored.Contains(segmentData.Type))
                // {
                //     continue;
                // }

                //var codePath = codeBasePath + "\\v" + versionAndSegment.Key + "\\";
                // var testPath = testBasePath + "\\v" + versionAndSegment.Key + "\\";

                // if (segmentData.IsCompositeType)
                // {
                //     codePath += "Composites\\";
                //     testPath += "Composites\\";
                //
                // }

                // var parseType = ParseType.x12Segment;
                // if (segmentData.IsCompositeType)
                //     parseType = ParseType.x12Element;

                //var fileSeachPath = codeBasePath + "\\v" + versionAndSegment.Key + "\\" + segmentData.Type + "_*.cs";
                // codePath += segmentData.Name + ".cs";
                // testPath += segmentData.Type + "Tests.cs";

                //we use a wildcard here as files can change name but keep the same prefix (e.g. 3010\BMG_BeginingSegmentForText[Transaction] and 3020\BMG_BeginingSegmentForText[Message])
                string[] matchingFiles;
                matchingFiles = System.IO.Directory.GetFiles(projectBasePath + "\\Eddy.x12.DomainModels.Transportation\\v" + versionAndSegment.Key + "\\" , segmentData.Type + "_*.cs");

                // if (segmentData.IsCompositeType)
                //     
                // else
                //     matchingFiles = System.IO.Directory.GetFiles(codeBasePath + "\\v" + versionAndSegment.Key + "\\", segmentData.Type + "_*.cs");

                if (matchingFiles.Length > 0) //don't regen if already exists
                    continue;

                var filesToWrite = new Dictionary<string, string>(); //path and code

                OnProcessUpdate?.Invoke($"Processing transaction set {version}-{segmentData.Type}");
                var segmentsInVersions = FindSegmentInAllVersions(segmentData.Type, versionAndSegments);
                OnProcessUpdate?.Invoke($"transaction set also exists in the following versions: " + string.Join(", ", segmentsInVersions.Keys));
                var concurrentParsedResults = new ConcurrentDictionary<string, ParsedTransactionSet>();

                //max is 50% of segments. I found that often times I was getting 95% in one batch of parallel queries then the other 5% would start which was less efficient
                // new ParallelOptions { MaxDegreeOfParallelism = segmentsInVersions.Count/2 }
                // 
                await Parallel.ForEachAsync(segmentsInVersions, async (otherSegment, token) =>
                {
                    OnProcessUpdate?.Invoke($"Parsing {otherSegment.Key}-{otherSegment.Value.Type}");
                    var rawPageData = await GetPage(otherSegment.Value.Url);
                    //wrap the node in an element so that there is only one root element
                    var wrappedNode = HtmlNode.CreateNode("<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + rawPageData + Environment.NewLine + "</div>");
                    Debug.WriteLine("Parsing: " + otherSegment.Key + "-" + segmentData.Type);
                    concurrentParsedResults.TryAdd(otherSegment.Key, parser.Parse(wrappedNode));
                });

                //write out the base item which would be the first item in the collection
                var parsedByVersion = concurrentParsedResults.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

                var lastCode = parsedByVersion.First();



                var generatedCode = codeGenerator.GenerateCode(lastCode.Value, "Eddy.x12.DomainModels.Transportation", version);
                var rootFile = generatedCode.First();
                var codeBasePath = projectBasePath + "\\Eddy.x12.DomainModels.Transportation\\v" + versionAndSegment.Key + "\\";
                WriteIfNotExists(codeBasePath, rootFile);

                foreach (var keyValuePair in generatedCode.Skip(1))
                {
                    WriteIfNotExists(codeBasePath + segmentData.Type + "\\", keyValuePair);
                }

                // var generatedTest = testGenerator.GenerateTests(lastCode.Value, parseType, version);
                //
                // if (!File.Exists(codePath))
                //     filesToWrite.Add(codePath, generatedCode);
                // if (!File.Exists(testPath))
                //     filesToWrite.Add(testPath, generatedTest);
                //
                OnProcessUpdate?.Invoke($"Initial code generated");


                foreach (var parsedItem in parsedByVersion.Skip(1))
                {
                    generatedCode = codeGenerator.GenerateCode(parsedItem.Value, "Eddy.x12.DomainModels.Transportation", parsedItem.Key);
                    rootFile = generatedCode.First();
                    codeBasePath = projectBasePath + "\\Eddy.x12.DomainModels.Transportation\\v" + parsedItem.Key + "\\";
                    WriteIfNotExists(codeBasePath, rootFile);

                    foreach (var keyValuePair in generatedCode.Skip(1))
                    {
                        WriteIfNotExists(codeBasePath + segmentData.Type + "\\", keyValuePair);
                    }
                }
                
                
                //
                // //I think there is a bug with this. It should take after the current version... not all versions
                // foreach (var parsedSegment in parsedByVersion.Skip(1)) //skip the first record as we just wrote it out above as our base item
                //     if (lastCode.Value.Equals(parsedSegment.Value)) //no change between versions
                //     {
                //         OnProcessUpdate?.Invoke($"generating inheritance code for {parsedSegment.Key}-{segmentData.Type}");
                //         codePath = projectBasePath + @"Eddy.x12\Models\v" + parsedSegment.Key + "\\";
                //         if (segmentData.IsCompositeType)
                //         {
                //             codePath += "Composites\\";
                //         }
                //         codePath += segmentData.Name + ".cs";
                //
                //
                //
                //         var generatedInheritanceCode = codeGenerator.GenerateInheritanceCodeFrom(lastCode.Value, parsedSegment.Key, lastCode.Key, parseType);
                //         if (!File.Exists(codePath))
                //             filesToWrite.Add(codePath, generatedInheritanceCode);
                //         lastCode = parsedSegment;
                //         //no test required
                //
                //
                //     }
                //     else
                //     {
                //         OnProcessUpdate?.Invoke($"Code Varied. Restarting inheritance tree {parsedSegment.Key}-{segmentData.Type}");
                //         codePath = projectBasePath + @"Eddy.x12\Models\v" + parsedSegment.Key + "\\";
                //         testPath = testBasePath + "\\v" + parsedSegment.Key + "\\";
                //
                //         if (segmentData.IsCompositeType)
                //         {
                //             codePath += "Composites\\";
                //             testPath += "Composites\\";
                //         }
                //         codePath += segmentData.Name + ".cs";
                //         testPath += segmentData.Type + "Tests.cs";
                //
                //
                //         generatedCode = codeGenerator.GenerateCode(parsedSegment.Value, parseType, parsedSegment.Key);
                //         generatedTest = testGenerator.GenerateTests(parsedSegment.Value, parseType, parsedSegment.Key);
                //         if (!File.Exists(codePath))
                //             filesToWrite.Add(codePath, generatedCode);
                //         if (!File.Exists(testPath))
                //             filesToWrite.Add(testPath, generatedTest);
                //         lastCode = parsedSegment;
                //     }
                //
                // foreach (var fileToWrite in filesToWrite)
                // {
                //     File.WriteAllText(fileToWrite.Key, fileToWrite.Value);
                // }
                //
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

    private void WriteIfNotExists(string basePath, KeyValuePair<string, string> file)
    {
        // if (!File.Exists(basePath + file.Key + ".cs"))
            File.WriteAllText(basePath + file.Key + ".cs", file.Value);
    }
}