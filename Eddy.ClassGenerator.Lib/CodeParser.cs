using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Eddy.ClassGenerator.Lib
{
    public class CodeParser
    {
        private static string RemoveSpecialCharacters(string input)
        {
            return input.Replace("/", "").Replace(" ", "").Replace("-", "").Replace(",", "").Replace("(", "").Replace(")", "").Replace("'", "").Replace(".", "");
        }

        private Model ParseRow(HtmlNode row, ParseType parseType, bool parseAsComplexType)
        {
            var textInfo = new CultureInfo("en-US", false).TextInfo;

            Regex matcherRegex;
            if (parseType == ParseType.x12Element || parseType == ParseType.x12Segment)
                matcherRegex = new Regex(@"[A-Z0-9]{2,3}-\d+");
            else if (parseType == ParseType.ediFactElement || parseType == ParseType.ediFactSegment)
                matcherRegex = new Regex(@"\d{3}");
            else
                throw new Exception("Need to select one type of document");

            var offset = 0;
            var columns = row.ChildNodes.ToList();

            if (string.IsNullOrEmpty(columns[0].InnerText.Trim()))
                offset = 1; //sometimes there is a hidden column at the front so we shift to the right

            if (!matcherRegex.IsMatch(columns[0 + offset].InnerText))
                return null;

            var position = columns[0 + offset].InnerText;



            // if (parseType == ParseType.x12)
            // {
            //     segmentType = position.Substring(0, position.IndexOf("-")); //will set the outerSegmentType to be AT7 for every column so a bit of a hack as it really only needs to be set once
            // }
            if (parseType == ParseType.ediFactElement || parseType == ParseType.ediFactSegment)
            {
                //  segmentType = "element1"; //the codes do not contain the name for edifact elements so we stub one in

                //elements use a format like 010 but we want to convert that to "1" for our purposes
                position = position.Substring(0, position.Length - 1);
                if (position.StartsWith("0"))
                    position = position.Substring(1);
            }

            position = position.Substring(position.IndexOf("-") + 1);


            var tempName = textInfo.ToTitleCase(columns[2 + offset].InnerText);
            var name = RemoveSpecialCharacters(tempName);

            var type = columns[3 + offset].InnerText;
            switch (type)
            {
                case "Numeric (N0)":
                    type = "int?";
                    break;
                case "Decimal number (R)":
                    type = "decimal?";
                    break;
                default:
                    type = "string";
                    break;
            }

            if (parseAsComplexType)
                type = columns[1].InnerText + "_" + name;

            var min = 0;
            var max = 0;
            if (!string.IsNullOrEmpty(columns[5 + offset].InnerText))
                min = int.Parse(columns[5 + offset].InnerText);
            if (!string.IsNullOrEmpty(columns[6 + offset].InnerText))
            {
                var maxAsString = columns[6 + offset].InnerText;
                if (maxAsString == "∞")
                    max = int.MaxValue;
                else
                    max = int.Parse(columns[6 + offset].InnerText.Replace(",", ""));
            }

            var model = new Model(position, name, type, min, max);

            var requirement = columns[4 + offset].InnerText;
            if (requirement == "Mandatory")
                model.IsRequired = true;

            return model;

        }

        public ParsedSegment Parse(HtmlNode document, ParseType parseType)
        {
            var result = new ParsedSegment();
            var textInfo = new CultureInfo("en-US", false).TextInfo;

            var header = document.SelectSingleNode("//h1");
            result.SegmentType = header.SelectSingleNode("span").InnerText;
            var segmentFriendlyName = textInfo.ToTitleCase(header.GetDirectInnerText());
            result.ClassName = result.SegmentType + "_" + RemoveSpecialCharacters(segmentFriendlyName);

            if (document.InnerText.Contains("not present in"))
                throw new FileLoadException("This type may not be supported in this release");

            var tableRoot = document.SelectSingleNode("div/div[3]"); //holds table and header
            var tableHeader = tableRoot.SelectSingleNode("div/div"); //first row and then first column
            if (tableHeader.InnerText != "Position")
            {
                throw new Exception("Failed to find table");
            }




            result.Items = new List<Model>();

            Model? currentItem = null;

            
            var elementNameRegEx = new Regex("^[A-Za-z0-9]{1,4}-\\d{2}");

            foreach (var row in tableRoot.SelectNodes("div").Skip(1)) //skip the header row
            {
                var columns = row.ChildNodes.ToList();

                if (columns[0].OriginalName == "details")
                {
                    //row has <details><summary> then the actual div table within it
                    var childRow = row.FirstChild.FirstChild.SelectSingleNode("div");
                    //complex type
                    var model = ParseRow(childRow, parseType, true);
                    result.Items.Add(model);
                }

                if (columns.Count > 3)
                {
                    currentItem = ParseRow(row, parseType, false);
                    if (currentItem!=null) 
                        result.Items.Add(currentItem);
                }
                else
                {
                    if (currentItem != null && row.FirstChild.OriginalName != "details") //details is sub elements and we don't want to validate them currently
                    {
                        ExtractValidations(row.InnerText, currentItem, elementNameRegEx);
                    }
                }
            }

            result.Items = result.Items.Distinct().ToList();

            //fix name collisions
            foreach (var item in result.Items)
            {
                var matchingNames = result.Items.Where(x => x.Name == item.Name).ToList();
                if (matchingNames.Count() > 1)
                {
                    for (int i = 1; i < matchingNames.Count(); i++)
                    {
                        matchingNames[i].Name += (i + 1);
                    }
                }
            }

            return result;
        }

        public void ExtractValidations(string text, Model currentItem, Regex elementNameRegEx)
        {
            var aRequiresB = new Regex("If (\\w+-\\d+) is present, then (\\w+-\\d+) is required");
            var ifOneThenAll = new Regex("If either (\\w+-\\d+) or (\\w+-\\d+) is present, then the other is required");
            var atLeastOneOf = new Regex("At least one of (\\w+-\\d+) or (\\w+-\\d+) is required");
            var onlyOneOf = new Regex("Only one of (\\w+-\\d+) or (\\w+-\\d+) may be present");
            var ifOneThenMore = new Regex("If (\\w+-\\d+) is present, then at least one of (\\w+-\\d+)");
            // var text = "If T1-02 is present, then T1-01 is required"; //ARequiresB
            // var text = "If either T1-04 or T1-05 is present, then the other is required";
            // var text = "At least one of T1-01 or T1-03 is required";
            //var text = "Only one of T1-01 or T1-03 may be present";

            if (aRequiresB.IsMatch(text))
            {
                currentItem.ARequiresBValidation.Add(ParseValidationMessage(text, elementNameRegEx));
                return;
            }

            if (ifOneThenAll.IsMatch(text))
            {
                currentItem.IfOneIsFilledAllAreRequiredValidations.Add(ParseValidationMessage(text, elementNameRegEx));
                return;
            }

            if (atLeastOneOf.IsMatch(text))
            {
                currentItem.AtLeastOneValidations.Add(ParseValidationMessage(text, elementNameRegEx));
                return;
            }

            if (onlyOneOf.IsMatch(text))
            {
                currentItem.OnlyOneOfValidations.Add(ParseValidationMessage(text, elementNameRegEx));
                return;
            }

            if (ifOneThenMore.IsMatch(text))
            {
                currentItem.IfOneIsFilledThenAtLeastOne.Add(ParseValidationMessage(text, elementNameRegEx));
                return;
            }

        }

        private ValidationData ParseValidationMessage(string message, Regex elementNameRegEx)
        {
            var parts = message.Split(' ');
            var data = new ValidationData();
            foreach (var part in parts)
            {
                if (elementNameRegEx.IsMatch(part))
                {
                    if (string.IsNullOrEmpty(data.FirstFieldPosition))
                        data.FirstFieldPosition = StripTypeFromPostion(part);
                    else
                        data.OtherFields.Add(StripTypeFromPostion(part));
                }
            }
            return data;
        }

        private string StripTypeFromPostion(string input)
        {
            return input.Substring(input.IndexOf("-") + 1).Replace(",", "").Trim();
        }

    }


}
