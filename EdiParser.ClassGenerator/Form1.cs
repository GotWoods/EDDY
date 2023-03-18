using System.Xml.Linq;
using System.Xml.XPath;
using EdiParser.ClassGenerator.Lib;
using HtmlAgilityPack;
using PuppeteerSharp;

namespace EdiParser.ClassGenerator;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void button2_Click(object sender, EventArgs e)
    {
        var s = await GetPage(txtEdifactElement.Text);
        var text = "<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + s + Environment.NewLine + "</div>";
        var newNode = HtmlNode.CreateNode(text);
        ParseData(newNode, ParseType.ediFactElement);
    }

    private async void button3_Click(object sender, EventArgs e)
    {
        var s = await GetPage(txtEdifactSegment.Text);
        var text = "<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + s + Environment.NewLine + "</div>";
        var newNode = HtmlNode.CreateNode(text);
        ParseData(newNode, ParseType.ediFactSegment);
    }

    private async void button4_Click(object sender, EventArgs e)
    {
        var s = await GetPage(txtX12.Text);
        var text = "<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + s + Environment.NewLine + "</div>";
        var newNode = HtmlNode.CreateNode(text);
        ParseData(newNode, ParseType.x12);
    }


    private async Task<string> GetPage(string url)
    {
        //var fetcher = new BrowserFetcher();
        //var result = await fetcher.DownloadAsync(BrowserFetcher.DefaultChromiumRevision);

        var browser = await Puppeteer.LaunchAsync(new LaunchOptions
        {
            Headless = true
            //    ExecutablePath = @"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
        });
        // Create a new page and go to Bing Maps
        var page = await browser.NewPageAsync();
        await page.GoToAsync(url, WaitUntilNavigation.Networkidle0);

        //await page.WaitForTimeoutAsync(2000);
        var select = await page.QuerySelectorAsync("main");
        var content = await page.EvaluateFunctionAsync<string>("e => e.innerHTML", select);
        //var innervalue = await select.GetPropertyAsync("innerText");

        //var data = await page.EvaluateExpressionAsync<string>(@"document.querySelector('main');");

        //var content = await page.GetContentAsync();
        await browser.CloseAsync();

        return content;
    }

    public void ParseData(HtmlNode document, ParseType parseType)
    {
        txtOutput.Text = "";
        txtTest.Text = "";

        var generator = new CodeGenerator();
        var results = generator.ParseData(document, parseType);
        txtOutput.Text = results.Code;
        txtTest.Text = results.Test;
    }


    }