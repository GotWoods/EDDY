using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Eddy.Core.Validation;
using HtmlAgilityPack;

namespace Eddy.ClassGenerator.Lib;

public class CodeGenerator
{
    private ValidationData ParseValidationMessage(string message, Regex elementNameRegEx)
    {
        var parts = message.Split(' ' );
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

    private Model FindFieldByPosition(string position, List<Model> fields)
    {
        foreach (var field in fields)
        {
            if (position == field.Position)
            {
                return field;
            }
        }
        return new Model(position, position, "string", 0, 0);
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

    private string RemoveSpecialCharacters(string input)
    {
        return input.Replace("/", "").Replace(" ", "").Replace("-", "").Replace(",", "").Replace("(", "").Replace(")", "").Replace("'", "").Replace(".", "");
    }

    public (string Code, string Test) ParseData(HtmlNode document, ParseType parseType)
    {
        var textInfo = new CultureInfo("en-US", false).TextInfo;

        var header = document.SelectSingleNode("//h1");
        var segmentType = header.SelectSingleNode("span").InnerText;
        var segmentFriendlyName = textInfo.ToTitleCase(header.GetDirectInnerText());
        var className = segmentType + "_" + RemoveSpecialCharacters(segmentFriendlyName);

        if (document.InnerText.Contains("not present in"))
            throw new FileLoadException("This type may not be supported in this release");

        var tableRoot = document.SelectSingleNode("div/div[3]"); //holds table and header
        var tableHeader = tableRoot.SelectSingleNode("div/div"); //first row and then first column
        if (tableHeader.InnerText != "Position")
        {
            throw new Exception("Failed to find table");
        }




        var items = new List<Model>();

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
                items.Add(model);
            }

            if (columns.Count > 3)
            {
                currentItem = ParseRow(row, parseType, false);
                items.Add(currentItem);
            }
            else
            {
                if (currentItem != null && row.FirstChild.OriginalName != "details") //details is sub elements and we don't want to validate them currently
                {
                    ExtractValidations(row.InnerText, currentItem, elementNameRegEx);
                }
            }
        }

        items = items.Distinct().ToList();

        //fix name collisions
        foreach (var item in items)
        {
            var matchingNames = items.Where(x => x.Name == item.Name).ToList();
            if (matchingNames.Count() > 1)
            {
                for (int i = 1; i < matchingNames.Count(); i++)
                {
                    matchingNames[i].Name += (i + 1);
                }
            }
        }

        var sb = new StringBuilder();
        if (parseType == ParseType.x12Segment || parseType == ParseType.x12Element)
        {
            sb.AppendLine("using Eddy.Core.Attributes;");
            sb.AppendLine("using Eddy.Core.Validation;");
            sb.AppendLine("using Eddy.x12.Internals;");
            sb.AppendLine();
            if (parseType == ParseType.x12Element)
                sb.AppendLine("namespace Eddy.x12.Models.Elements;");
            else
                sb.AppendLine("namespace Eddy.x12.Models;");
            sb.AppendLine();
            sb.AppendLine($"[Segment(\"{segmentType}\")]");
            sb.Append($"public class {className} : ");
            sb.AppendLine(parseType == ParseType.x12Element ? "EdiX12Component" : "EdiX12Segment");
        }
        else if (parseType == ParseType.ediFactElement)
            sb.AppendLine($"public class {className} : IElement ");
        else if (parseType == ParseType.ediFactSegment)
            sb.AppendLine($"public class {className} ");
        sb.AppendLine("{");

        foreach (var item in items) sb.AppendLine(item.ToString());


        sb.AppendLine("\tpublic override ValidationResult Validate()");
        sb.AppendLine("\t{");
        sb.AppendLine($"\t\tvar validator = new BasicValidator<{className}>(this);");

        //required validations
        foreach (var model in items)
        {
            if (model.IsRequired)
            {
                sb.AppendLine($"\t\tvalidator.Required(x=>x.{model.Name});");
            }

            foreach (var x in model.AtLeastOneValidations)
            {
                sb.AppendLine($"\t\tvalidator.AtLeastOneIsRequired(x=>x.{FindFieldByPosition(x.FirstFieldPosition, items).Name}, x=>x.{FindFieldByPosition(x.OtherFields[0], items).Name});");
            }

            foreach (var x in model.IfOneIsFilledAllAreRequiredValidations)
            {
               sb.AppendLine($"\t\tvalidator.IfOneIsFilled_AllAreRequired(x=>x.{FindFieldByPosition(x.FirstFieldPosition, items).Name}, x=>x.{FindFieldByPosition(x.OtherFields[0], items).Name});");
            }

            foreach (var x in model.ARequiresBValidation)
            {
                sb.AppendLine($"\t\tvalidator.ARequiresB(x=>x.{FindFieldByPosition(x.FirstFieldPosition, items).Name}, x=>x.{FindFieldByPosition(x.OtherFields[0], items).Name});");
            }

            foreach (var x in model.OnlyOneOfValidations)
            {
                sb.AppendLine($"\t\tvalidator.OnlyOneOf(x=>x.{FindFieldByPosition(x.FirstFieldPosition, items).Name}, x=>x.{FindFieldByPosition(x.OtherFields[0], items).Name});");
            }

            foreach (var x in model.IfOneIsFilledThenAtLeastOne)
            {
                sb.Append($"\t\tvalidator.IfOneIsFilledThenAtLeastOne(x=>x.{FindFieldByPosition(x.FirstFieldPosition, items).Name}");
                foreach (var otherField in x.OtherFields)
                {
                    sb.Append($", x=>x.{FindFieldByPosition(otherField, items).Name}");
                }
                sb.AppendLine(");");
            }
        }

        //length validations
        foreach (var model in items)
        {
            if (model.Min == 0 && model.Max == 0) //it is a complex type and should not be validated
                continue;
            else if (model.Min == model.Max)
                sb.AppendLine($"\t\tvalidator.Length(x => x.{model.Name}, {model.Min});");
            else
                sb.AppendLine($"\t\tvalidator.Length(x => x.{model.Name}, {model.Min}, {model.Max});");
        }

        sb.AppendLine("\t\treturn validator.Results;");
        sb.AppendLine("\t}");

        sb.AppendLine("}");
      

        var sbTest = new StringBuilder();
        sbTest.AppendLine("using Eddy.Core.Validation;");
        sbTest.AppendLine("using Eddy.x12.Mapping;");
        sbTest.AppendLine("using Eddy.x12.Models;");
        sbTest.AppendLine();
        sbTest.AppendLine("namespace Eddy.Tests.x12.Models;");
        sbTest.AppendLine();
        sbTest.AppendLine($"public class {segmentType}Tests");
        sbTest.AppendLine("{");
        sbTest.AppendLine("\t[Fact]");
        sbTest.AppendLine("\tpublic void Parse_ShouldReturnCorrectObject()");
        sbTest.AppendLine("\t{");
        if (parseType == ParseType.x12Element)
        {
            sbTest.Append($"\t\tvar x12Line = \"");
        }
        else
        {
            sbTest.Append($"\t\tstring x12Line = \"{segmentType}");
        }
        foreach (var model in items)
        {
            sbTest.Append("*" + model.TestValue);
        }
        sbTest.AppendLine("\";");
        sbTest.AppendLine("");
        sbTest.AppendLine($"\t\tvar expected = new {className}()");
        sbTest.AppendLine("\t\t{");
        foreach (var model in items)
        {
            if (model.IsDataTypeNumeric)
                sbTest.AppendLine($"\t\t\t{model.Name} = {model.TestValue},");
            else
                sbTest.AppendLine($"\t\t\t{model.Name} = \"{model.TestValue}\",");
        }
        sbTest.AppendLine("\t\t};");
        sbTest.AppendLine("");
        sbTest.AppendLine($"\t\tvar actual = Map.MapObject<{className}>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);");
        sbTest.AppendLine("\t\tAssert.Equivalent(expected, actual);");
        sbTest.AppendLine("\t}");
        sbTest.AppendLine();

        foreach (var model in items) 
        {
            if (model.IsRequired)
            {
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(model, true)}, false)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(model, false)}, true)]");
                sbTest.Append($"\tpublic void Validation_Required{model.Name}(");
                sbTest.Append($"{model.DataType.Replace("?", "")} {FirstCharToLowerCase(model.Name)}, "); //can not pass in a nullable with inline data
                sbTest.AppendLine($"bool isValidExpected)");
                sbTest.AppendLine("\t{");
                sbTest.AppendLine($"\t\tvar subject = new {className}();");
                foreach (var requiredItem in items.Where(x=>x.IsRequired && x.Name != model.Name))
                {
                    if (requiredItem.IsDataTypeNumeric)
                        sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = {requiredItem.TestValue};");
                    else
                        sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = \"{requiredItem.TestValue}\";");
                    
                }

                if (model.IsDataTypeNumeric)
                {
                    sbTest.AppendLine($"\t\tif ({FirstCharToLowerCase(model.Name)} > 0)");
                }
                sbTest.AppendLine($"\t\tsubject.{model.Name} = {FirstCharToLowerCase(model.Name)};");
                sbTest.AppendLine("\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }

            

            if (model.IfOneIsFilledAllAreRequiredValidations.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.IfOneIsFilledAllAreRequiredValidations, items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], true)}, true)]"); 
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, false)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, false)]");
                sbTest.Append($"\tpublic void Validation_AllAreRequired{model.Name}(");
                sbTest.AppendLine(GenerateTestBody(model.IfOneIsFilledAllAreRequiredValidations, items, className));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.IfOneIsFilledAllAreRequired)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }

            if (model.ARequiresBValidation.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.ARequiresBValidation, items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, false)]");
                sbTest.Append($"\tpublic void Validation_ARequiresB{model.Name}(");
                sbTest.AppendLine(GenerateTestBody(model.ARequiresBValidation, items, className));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.ARequiresB)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }

            if (model.AtLeastOneValidations.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.AtLeastOneValidations, items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], true)}, false)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)},{GenerateInlineDataValue(orderedFields[1], false)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]");
                sbTest.Append($"\tpublic void Validation_AtLeastOne{model.Name}(");
                sbTest.AppendLine(GenerateTestBody(model.AtLeastOneValidations, items, className));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.AtLeastOneIsRequired)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }

            if (model.OnlyOneOfValidations.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.OnlyOneOfValidations, items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], false)}, false)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)}, {GenerateInlineDataValue(orderedFields[1], false)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]");
                sbTest.Append($"\tpublic void Validation_OnlyOneOf{model.Name}(");
                sbTest.AppendLine(GenerateTestBody(model.OnlyOneOfValidations, items, className));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.OnlyOneOf)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }
            
            if (model.IfOneIsFilledThenAtLeastOne.Any())
            {
                var orderedFields = OrderFieldsForTestSignature(model.IfOneIsFilledThenAtLeastOne, items);
                sbTest.AppendLine("\t[Theory]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], true)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], false)}, false)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], true)},{GenerateInlineDataValue(orderedFields[1], false)}, true)]");
                sbTest.AppendLine($"\t[InlineData({GenerateInlineDataValue(orderedFields[0], false)}, {GenerateInlineDataValue(orderedFields[1], true)}, true)]");
                sbTest.Append($"\tpublic void Validation_IfOneSpecifiedThenOneMoreRequired_{model.Name}(");
                sbTest.AppendLine(GenerateTestBody(model.IfOneIsFilledThenAtLeastOne, items, className));
                sbTest.AppendLine($"\t\tTestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.{nameof(ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired)});");
                sbTest.AppendLine("\t}");
                sbTest.AppendLine();
            }
        }
        sbTest.AppendLine("}");
        return (Code: sb.ToString(), Test: sbTest.ToString());
    }

    private string GenerateInlineDataValue(Model item, bool generateBlankDefault)
    {
        if (generateBlankDefault)
        {
            if (item.IsDataTypeNumeric)
                return "0";
            return "\"\"";
        }

        if (item.IsDataTypeNumeric)
            return item.TestValue.ToString();
        return $"\"{item.TestValue}\"";
    }

    private List<Model> OrderFieldsForTestSignature(List<ValidationData> validations, List<Model> items)
    {
        var result = new List<Model>();
        foreach (var validationData in validations)
        {
            foreach (var field in validationData.GetAllFieldDataOrdered())
            {
                var foundField = FindFieldByPosition(field, items);
                result.Add(foundField);
            }
        }
        return result;
    }

     private string GenerateTestBody(List<ValidationData> validations, List<Model> items, string className)
    {
        var sbTest = new StringBuilder();
        foreach (var validationData in validations )
        {
            foreach (var field in validationData.GetAllFieldDataOrdered())
            {
                var foundField = FindFieldByPosition(field, items);
                sbTest.Append($"{foundField.DataType.Replace("?", "")} {FirstCharToLowerCase(foundField.Name)}, ");
            }
        }
        sbTest.AppendLine($"bool isValidExpected)");
        sbTest.AppendLine("\t{");
        sbTest.AppendLine($"\t\tvar subject = new {className}();");
        
        //may impact the test if the variable is used in a validation
        foreach (var requiredItem in items.Where(x => x.IsRequired))
        {
            if (requiredItem.IsDataTypeNumeric)
                sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = {requiredItem.TestValue};");
            else
                sbTest.AppendLine($"\t\tsubject.{requiredItem.Name} = \"{requiredItem.TestValue}\";");
        }

        foreach (var validationData in validations)
        {
            foreach (var field in validationData.GetAllFieldDataOrdered())
            {
                var otherField = FindFieldByPosition(field, items);
                
                if (otherField.IsDataTypeNumeric)
                {
                    sbTest.AppendLine($"\t\tif ({FirstCharToLowerCase(otherField.Name)} > 0)");
                }
                sbTest.AppendLine($"\t\tsubject.{otherField.Name} = {FirstCharToLowerCase(otherField.Name)};");
            }
        }

     
        return sbTest.ToString();
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
    private string FirstCharToLowerCase(string str)
    {
        if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
            return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str.Substring(1);
        return str;
    }
}

