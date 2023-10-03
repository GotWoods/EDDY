using System.Collections.Generic;
using System.Text;
using System.Xml.XPath;

namespace Eddy.ClassGenerator.Lib;



public class CodeGenerator
{
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

    private static string RemoveSpecialCharacters(string input)
    {
        return input.Replace("/", "").Replace(" ", "").Replace("-", "").Replace(",", "").Replace("(", "").Replace(")", "").Replace("'", "").Replace(".", "");
    }

    public static string GetCodeClassName(string segmentType, string friendlyName)
    {
        return segmentType + "_" + RemoveSpecialCharacters(friendlyName);
    }

    public string GenerateCode(ParsedSegment parsed, ParseType parseType, string namespaceVersion)
    {
        var sb = new StringBuilder();
        if (parseType == ParseType.x12Segment || parseType == ParseType.x12Element)
        {
            sb.AppendLine("using Eddy.Core.Attributes;");
            sb.AppendLine("using Eddy.Core.Validation;");
            sb.AppendLine("using Eddy.x12.Models.Elements;");
            sb.AppendLine();
            if (parseType == ParseType.x12Element)
                sb.AppendLine("namespace Eddy.x12.Models.v" + namespaceVersion + ".Composites;");
            else
                sb.AppendLine("namespace Eddy.x12.Models.v" + namespaceVersion + ";");
            sb.AppendLine();
            sb.AppendLine($"[Segment(\"{parsed.SegmentType}\")]");
            sb.Append($"public class {parsed.ClassName} : ");
            sb.AppendLine(parseType == ParseType.x12Element ? "EdiX12Component" : "EdiX12Segment");
        }
        else if (parseType == ParseType.ediFactElement)
            sb.AppendLine($"public class {parsed.ClassName} : IElement ");
        else if (parseType == ParseType.ediFactSegment)
            sb.AppendLine($"public class {parsed.ClassName} ");
        sb.AppendLine("{");

        foreach (var item in parsed.Items) 
            sb.AppendLine(item.ToString());


        sb.AppendLine("\tpublic override ValidationResult Validate()");
        sb.AppendLine("\t{");
        sb.AppendLine($"\t\tvar validator = new BasicValidator<{parsed.ClassName}>(this);");

        //required validations
        foreach (var model in parsed.Items)
        {
            if (model.IsRequired)
            {
                sb.AppendLine($"\t\tvalidator.Required(x=>x.{model.Name});");
            }

            foreach (var x in model.AtLeastOneValidations)
            {
                sb.AppendLine($"\t\tvalidator.AtLeastOneIsRequired(x=>x.{FindFieldByPosition(x.FirstFieldPosition, parsed.Items).Name}, x=>x.{FindFieldByPosition(x.OtherFields[0], parsed.Items).Name});");
            }

            foreach (var x in model.IfOneIsFilledAllAreRequiredValidations)
            {
               sb.AppendLine($"\t\tvalidator.IfOneIsFilled_AllAreRequired(x=>x.{FindFieldByPosition(x.FirstFieldPosition, parsed.Items).Name}, x=>x.{FindFieldByPosition(x.OtherFields[0], parsed.Items).Name});");
            }

            foreach (var x in model.ARequiresBValidation)
            {
                sb.AppendLine($"\t\tvalidator.ARequiresB(x=>x.{FindFieldByPosition(x.FirstFieldPosition, parsed.Items).Name}, x=>x.{FindFieldByPosition(x.OtherFields[0], parsed.Items).Name});");
            }

            foreach (var x in model.OnlyOneOfValidations)
            {
                sb.AppendLine($"\t\tvalidator.OnlyOneOf(x=>x.{FindFieldByPosition(x.FirstFieldPosition, parsed.Items).Name}, x=>x.{FindFieldByPosition(x.OtherFields[0], parsed.Items).Name});");
            }

            foreach (var x in model.IfOneIsFilledThenAtLeastOne)
            {
                sb.Append($"\t\tvalidator.IfOneIsFilledThenAtLeastOne(x=>x.{FindFieldByPosition(x.FirstFieldPosition, parsed.Items).Name}");
                foreach (var otherField in x.OtherFields)
                {
                    sb.Append($", x=>x.{FindFieldByPosition(otherField, parsed.Items).Name}");
                }
                sb.AppendLine(");");
            }
        }

        //length validations
        foreach (var model in parsed.Items)
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

        var code = sb.ToString();
        if (parseType == ParseType.x12Element) //ugly but it works to change the composites to be 0 based instead of 1 based like the segmetns are
        {
            code = code
                .Replace("[Position(01)]", "[Position(00)]")
                .Replace("[Position(02)]", "[Position(01)]")
                .Replace("[Position(03)]", "[Position(02)]")
                .Replace("[Position(04)]", "[Position(03)]")
                .Replace("[Position(05)]", "[Position(04)]")
                .Replace("[Position(06)]", "[Position(05)]")
                .Replace("[Position(07)]", "[Position(06)]")
                .Replace("[Position(08)]", "[Position(07)]")
                .Replace("[Position(09)]", "[Position(08)]")
                .Replace("[Position(10)]", "[Position(09)]")
                .Replace("[Position(11)]", "[Position(10)]")
                .Replace("[Position(12)]", "[Position(11)]")
                .Replace("[Position(13)]", "[Position(12)]")
                .Replace("[Position(14)]", "[Position(13)]")
                .Replace("[Position(15)]", "[Position(14)]")
                .Replace("[Position(16)]", "[Position(15)]")
                .Replace("[Position(17)]", "[Position(16)]")
                .Replace("[Position(18)]", "[Position(17)]")
                .Replace("[Position(19)]", "[Position(18)]")
                .Replace("[Position(20)]", "[Position(19)]")
                .Replace("[Position(21)]", "[Position(20)]")
                .Replace("[Position(22)]", "[Position(21)]")
                .Replace("[Position(23)]", "[Position(22)]")
                .Replace("[Position(24)]", "[Position(23)]")
                .Replace("[Position(25)]", "[Position(24)]")
                .Replace("[Position(26)]", "[Position(25)]")
                .Replace("[Position(27)]", "[Position(26)]")
                .Replace("[Position(28)]", "[Position(27)]")
                .Replace("[Position(29)]", "[Position(28)]")
                .Replace("[Position(30)]", "[Position(29)]");


        }

        return code;
    }
    
    public string GenerateInheritanceCodeFrom(ParsedSegment lastCode, string currentVersion, string lastVersion, ParseType parseType)
    {
        var sb = new StringBuilder();

        if (parseType == ParseType.ediFactSegment)
        {
            sb.AppendLine("namespace Eddy.x12.Models.v" + currentVersion + ";");
            sb.AppendLine();
            sb.AppendLine($"public class {lastCode.ClassName} : Eddy.x12.Models.v{lastVersion}.{lastCode.ClassName}");
        }
        else
        {
            sb.AppendLine("namespace Eddy.x12.Models.v" + currentVersion + ".Composites;");
            sb.AppendLine();
            sb.AppendLine($"public class {lastCode.ClassName} : Eddy.x12.Models.v{lastVersion}.Composites.{lastCode.ClassName}");
        }
        sb.AppendLine("{");
        sb.AppendLine("}");
        return sb.ToString();
    }
}