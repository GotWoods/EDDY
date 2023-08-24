using Eddy.ClassGenerator.Lib;
using HtmlAgilityPack;
using PuppeteerSharp;

namespace Eddy.ClassGenerator;

public partial class Form1 : Form
{
    private readonly string projectBasePath = @"C:\Source\EdiParser\";

    public Form1()
    {
        InitializeComponent();
    }


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

    public void ParseData(HtmlNode document, ParseType parseType)
    {
        txtOutput.Text = "";
        txtTest.Text = "";

        var generator = new CodeGenerator();
        var results = generator.ParseAndGenerateData(document, parseType, "TODO");
        txtOutput.Text = results.Code;
        txtTest.Text = results.Test;
    }




    private async void button5_Click(object sender, EventArgs e)
    {
        var s = await GetPage(txtx12Element.Text);
        var text = "<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + s + Environment.NewLine + "</div>";
        var newNode = HtmlNode.CreateNode(text);

        ParseData(newNode, ParseType.x12Element);
    }

    private async void btnx12Segment_Click(object sender, EventArgs e)
    {
        var s = await GetPage(txtX12.Text);
        var text = "<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + s + Environment.NewLine + "</div>";
        var newNode = HtmlNode.CreateNode(text);


        ParseData(newNode, ParseType.x12Segment);
    }

    private async void btnx12BatchConvert_Click(object sender, EventArgs e)
    {
        this.Cursor = Cursors.WaitCursor;
        try
        {
            var x = new BatchGenerator();
            await x.Start(projectBasePath, int.Parse(this.txtBatchCount.Text));
        }
        finally
        {
            this.Cursor = Cursors.Default;
        }
    }

    private async void btnEdifactElement_Click(object sender, EventArgs e)
    {
        var s = await GetPage(txtEdifactElement.Text);
        var text = "<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + s + Environment.NewLine + "</div>";
        var newNode = HtmlNode.CreateNode(text);
        ParseData(newNode, ParseType.ediFactElement);
    }

    private async void btnEdifactSegment_Click(object sender, EventArgs e)
    {
        var s = await GetPage(txtEdifactSegment.Text);
        var text = "<div xmlns:xlink=\"http://dummy.org/schema\" >" + Environment.NewLine + s + Environment.NewLine + "</div>";
        var newNode = HtmlNode.CreateNode(text);
        ParseData(newNode, ParseType.ediFactSegment);
    }
}