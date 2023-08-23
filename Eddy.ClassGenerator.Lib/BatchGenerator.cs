using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PuppeteerSharp;

namespace Eddy.ClassGenerator.Lib;

public class BatchGenerator
{
    private string[] x12Versions = new string[] { "3010", "3020", "3030", "3040", "3050", "3060", "3070" };
    //3010-3070
    //4010-4060
    //5010-5050
    //6010-6050
    //7010-7060
    //8010-8040


    public async Task Start(string projectBasePath, int batchCount)
    {
        bool isBase = true;
        string version = "3010";
        //get segments for version
        var page = await GetPage("https://www.stedi.com/edi/x12-00" + version + "/segment");
        //some sort of collection
        //Version[segment]

        var pageText = "<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + page + Environment.NewLine + "</div>";
        var newNode = HtmlNode.CreateNode(pageText);
        var segments = newNode.SelectNodes("/div/div/ul/li");

        //var existingFiles = GetExistingFiles();

        var counter = 0;
        var modelPath = projectBasePath + @"Eddy.x12\Models\v" + version;
        var testPath = projectBasePath + @"Eddy.Tests.x12\Models";
        foreach (var item in segments)
        {
            var link = item.SelectSingleNode("a");
            var type = link.SelectSingleNode("h2/span").InnerText;

            // if (existingFiles.Contains(type))
            //     continue;

            var s = await GetPage("https://www.stedi.com" + link.GetAttributeValue("href", ""));
            var text = "<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + s + Environment.NewLine + "</div>";
            var newNode2 = HtmlNode.CreateNode(text);
            //     ParseData(newNode2, ParseType.x12);
            var generator = new CodeGenerator();
            var results = generator.ParseData(newNode2, ParseType.x12Segment);
            counter++;

            File.WriteAllText(modelPath + "\\" + results.codeClassName + ".cs", results.Code);
            //File.WriteAllText(testPath + "\\" + type + "Tests.cs", results.Test);


            if (counter >= batchCount)
                break;
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