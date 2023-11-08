#nullable enable
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using HtmlAgilityPack;

namespace Eddy.ClassGenerator.Lib;

public class TransactionSetParser
{
    private List<ITransactionSetModel> ParseSection(HtmlNode dataRoot, string expectedHeading)
    {
        var result = new List<ITransactionSetModel>();
        var headerText = dataRoot.SelectSingleNode("h2").InnerText;
        if (headerText != expectedHeading)
            throw new Exception("Expected heading " + expectedHeading + " but got " + headerText);

        var headerRoot = dataRoot.SelectSingleNode("div");
        var tableHeader = dataRoot.SelectSingleNode("div/header/div"); //first row and then first column
        if (tableHeader.InnerText != "Position") throw new Exception("Failed to find table");

        //ITransactionSetModel currentItem = null;
        //var elementNameRegEx = new Regex("^[A-Za-z0-9]{1,4}-\\d{2}");

        foreach (var row in headerRoot.SelectNodes("ol/li"))
        {
            var currentItem = ParseRow(row);
            result.Add(currentItem);
        }

        return result;
    }

    public ParsedTransactionSet Parse(HtmlNode document)
    {
        var result = new ParsedTransactionSet();
        var textInfo = new CultureInfo("en-US", false).TextInfo;

        var header = document.SelectSingleNode("//h1");
        result.SegmentType = header.SelectSingleNode("span").InnerText;
        var segmentFriendlyName = textInfo.ToTitleCase(header.GetDirectInnerText());
        result.ClassName = result.SegmentType + "_" + CodeGenerator.RemoveSpecialCharacters(segmentFriendlyName);

        // if (document.InnerText.Contains("not present in"))
        //     throw new FileLoadException("This type may not be supported in this release");

        var dataRoot = document.SelectNodes("div/div[3]/div"); //holds Heading/Detail/Summary sections
        if (!dataRoot[0].InnerText.Contains("Heading")) //sometimes there is a div above that explains the transaction set
            dataRoot = document.SelectNodes("div/div[4]/div"); //holds Heading/Detail/Summary sections

        result.Header = ParseSection(dataRoot[0], "Heading");
        if (dataRoot.Count > 1)
            result.Detail = ParseSection(dataRoot[1], "Detail");
        if (dataRoot.Count > 2)
            result.Summary = ParseSection(dataRoot[2], "Summary");

        var position = 1;
        foreach (var transactionSetModel in result.Header)
        {
            transactionSetModel.Position = position;
            position++;
        }

        foreach (var transactionSetModel in result.Detail)
        {
            transactionSetModel.Position = position;
            position++;
        }

        foreach (var transactionSetModel in result.Summary)
        {
            transactionSetModel.Position = position;
            position++;
        }

        //fix name collisions
        foreach (var item in result.Header)
        {
            var matchingNames = result.Header.Where(x => x.Name == item.Name).ToList();
            if (matchingNames.Count() > 1)
                for (var i = 1; i < matchingNames.Count(); i++)
                    matchingNames[i].Name += i + 1;
        }

        foreach (var item in result.Detail)
        {
            var matchingNames = result.Header.Where(x => x.Name == item.Name).ToList();
            if (matchingNames.Count() > 1)
                for (var i = 1; i < matchingNames.Count(); i++)
                    matchingNames[i].Name += i + 1;
        }

        foreach (var item in result.Summary)
        {
            var matchingNames = result.Header.Where(x => x.Name == item.Name).ToList();
            if (matchingNames.Count() > 1)
                for (var i = 1; i < matchingNames.Count(); i++)
                    matchingNames[i].Name += i + 1;
        }

        return result;
    }

    public ITransactionSetModel ParseRow(HtmlNode row)
    {
        //if it is an anchor tag then it is a raw segment
        //if it is a "details" tag then it is an expanding loop section
        if (row.FirstChild.Name == "a")
        {
            var columns = row.FirstChild.ChildNodes.ToList(); //these are spans that have the data
            var m = new TransactionSetLineModel();
            m.SegmentType = columns[1].InnerText;
            m.Name = columns[2].InnerText;

            if (m.Name.EndsWith("Mandatory-&gt;"))
            {
                m.Required = true;
                m.Name = m.Name.Replace("Mandatory-&gt;", "");
            }

            m.Name = m.Name.Replace("Optional-&gt;", "");
            m.Name = CodeGenerator.RemoveSpecialCharacters(m.Name);
            var maxText = columns[3].InnerText;
            if (!maxText.Contains("Max"))
                throw new Exception("Expected Max Use column to contain the word Max");


            maxText = maxText.Replace("Max ", "");
            if (maxText == "&gt;1")
            {
                m.Min = 1;
                m.Max = int.MaxValue;
            }
            else
            {
                m.Max = int.Parse(maxText);
            }

            return m;
        }

        if (row.FirstChild.Name == "details")
        {
            var nameRow = row.FirstChild.SelectSingleNode("summary/div");
            //get the name
            var childModel = new TransactionSetLoopModel();

            /*
                /div/span[1] is the name (e.g. N7)
                /div/span[2] contains the Mandatory/Optional
                /div/div contains the repeat
             */

            var spans = nameRow.SelectNodes("span");
            childModel.Name = CodeGenerator.RemoveSpecialCharacters(spans[0].InnerText);
            childModel.Required = spans[1].InnerText?.IndexOf("Mandatory") > 0;

            var maxText = nameRow.SelectSingleNode("div").InnerText;
            maxText = maxText.Replace("Repeat", "").Replace("<!-- -->", "").Trim();
            if (maxText == "&gt;1")
            {
                childModel.Min = 1;
                childModel.Max = int.MaxValue;
            }
            else
            {
                childModel.Max = int.Parse(maxText);
            }

            var position = 1;
            foreach (var childItems in row.FirstChild.SelectNodes("ol/li"))
            {
                var transactionSetModel = ParseRow(childItems);
                transactionSetModel.Position = position;
                childModel.Children.Add(transactionSetModel);
                position++;
            }


            return childModel;
        }

        throw new Exception("Could not parse parent type");
    }
}