#nullable enable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Eddy.x12;
using HtmlAgilityPack;
using PuppeteerSharp.Messaging;

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

        var counter = 1;
        foreach (var transactionSetModel in result.Header)
        {
            transactionSetModel.Position = counter.ToString().PadLeft(3, '0');
            counter++;
        }

        foreach (var transactionSetModel in result.Detail)
        {
            transactionSetModel.Position = counter.ToString().PadLeft(3, '0');
            counter++;
        }

        foreach (var transactionSetModel in result.Summary)
        {
            transactionSetModel.Position = counter.ToString().PadLeft(3, '0');
            counter++;
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
            m.Position = columns[0].InnerText;
            m.SegmentType = columns[1].InnerText;
            m.Name = columns[2].InnerText;

            if (m.Name.EndsWith("Mandatory-&gt;"))
            {
                m.Required = true;
                m.Name = m.Name.Replace("Mandatory-&gt;", "");
            }

            m.Name = m.Name.Replace("Optional-&gt;", "");

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
        else if (row.FirstChild.Name == "details")
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
            childModel.Name = spans[0].InnerText;
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

            foreach (var childItems in row.FirstChild.SelectNodes("ol/li"))
            {
                childModel.Children.Add(ParseRow(childItems));
            }

            return childModel;
        }
        else
            throw new Exception("Could not parse parent type");
    }
}


/*
 * lines
 * N1 loop
 *  lines
 * lines
 *
 */

public interface ITransactionSetModel
{
    string Position { get; set; }
    string Name { get; set; }
    public bool Required { get; set; }
    public int Max { get; set; }
}

public class TransactionSetLineModel : ITransactionSetModel
{
    public string Position { get; set; } = string.Empty;
    public string SegmentType { get; set; } = string.Empty;

    public bool Required { get; set;}
    public int Max { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Min { get; set; }

    public override string ToString()
    {
        //var name = Name.Substring(0, Name.IndexOf("_") - 1);
        var segment = EdiSectionParserFactory.GetSegmentFor("3010", SegmentType);
        var segmentWithoutPrefix = segment.Name.Substring(segment.Name.IndexOf("_")+1);
        var sb = new StringBuilder();
        sb.AppendLine($"\t[SectionPosition({Position})]");
        if (Max > 1)
            sb.Append($"\tpublic List<{segment.Name}> {segmentWithoutPrefix} {{ get; set; }} = new();");
        else
        {
            if (Required)
                sb.Append($"\tpublic {segment.Name} {segmentWithoutPrefix} {{ get; set; }} = new();");
            else
                sb.Append($"\tpublic {segment.Name}? {segmentWithoutPrefix} {{ get; set; }}");
        }

        return sb.ToString();
    }
}

public class TransactionSetLoopModel : ITransactionSetModel
{
    public string Position { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public List<ITransactionSetModel> Children { get; set; } = new();
    public bool Required { get; set; }
    public int Max { get; set; }
    public int Min { get; set; }


    public List<KeyValuePair<string, string>> GenerateFiles(string prefix, string @namespace)
    {
        var results = new List<KeyValuePair<string, string>>();
        var sb = new StringBuilder();
        sb.AppendLine("using Eddy.Core.Attributes;");
        sb.AppendLine("using Eddy.Core.Validation;");
        sb.AppendLine("using Eddy.x12.Models.Elements;");
        sb.AppendLine();
        sb.AppendLine();

        sb.AppendLine($"namespace {@namespace}");
        sb.AppendLine();
        sb.AppendLine($"public class {prefix}{Name} {{");
        foreach (var item in Children)
        {
            if (item is TransactionSetLoopModel loop)
            {
                sb.AppendLine($"\t[UnknownPosition] List<{loop.Name}> {loop.Name} {{get;set;}}");
                var newPrefix = "";
                if (prefix == "")
                {
                    newPrefix = Name + "_";
                }
                else
                {
                    newPrefix = prefix + "_" + Name + "_";
                }

                results.AddRange(loop.GenerateFiles(newPrefix, @namespace));
            }
            else
            {
                sb.AppendLine(item.ToString());
            }
        }
        sb.AppendLine("}");

        // sb.AppendLine($"\t[SectionPosition(??)]");
        // sb.Append($"\tpublic {Name} ");
        // sb.AppendLine("{ get; set; }");
        //
        results.Add(new KeyValuePair<string, string>(Name, sb.ToString()));
        return results;
    }
} 




public class ParsedTransactionSet
{
    public string SegmentType { get; set; }
    public string ClassName { get; set; }

    public List<ITransactionSetModel> Header { get; set; } = new();
    public List<ITransactionSetModel> Detail { get; set; } = new();
    public List<ITransactionSetModel> Summary { get; set; } = new();

    // public override bool Equals(object obj)
    // {
    //     var compareTo = obj as ParsedSegment;
    //     if (compareTo == null)
    //         return false;
    //
    //     if (this.Items.Count != compareTo.Items.Count)
    //         return false;
    //
    //     for (var index = 0; index < this.Items.Count; index++)
    //     {
    //         if (!this.Items[index].DeepEquals(compareTo.Items[index]))
    //             return false;
    //     }
    //     return true;
    // }
    //
    // public override int GetHashCode()
    // {
    //     return HashCode.Combine(SegmentType, ClassName, Items);
    // }
}