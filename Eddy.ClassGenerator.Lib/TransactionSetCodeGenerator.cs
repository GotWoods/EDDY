using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Eddy.ClassGenerator.Lib;

public class TransactionSetCodeGenerator
{
    private Model FindFieldByPosition(string position, List<Model> fields)
    {
        foreach (var field in fields)
            if (position == field.Position)
                return field;
        return new Model(position, position, "string", 0, 0);
    }

    internal static string RemoveSpecialCharacters(string input)
    {
        return input.Replace("/", "").Replace(" ", "").Replace("-", "").Replace(",", "").Replace("(", "").Replace(")", "").Replace("'", "").Replace(".", "");
    }

    public static string GetCodeClassName(string segmentType, string friendlyName)
    {
        return segmentType + "_" + RemoveSpecialCharacters(friendlyName);
    }

    private (string code, List<KeyValuePair<string,string>> files) GenerateSection(List<ITransactionSetModel> parts, string @namespace)
    {
        var sb = new StringBuilder();
        List<KeyValuePair<string, string>> files = new();

        foreach (var part in parts)
            if (part is TransactionSetLoopModel loop)
            {
                sb.AppendLine($"\t[SectionPosition({part.Position})] List<{part.Name}> {part.Name} {{get;set;}} = new();");
                files.AddRange(loop.GenerateFiles("", @namespace));
                //need to write out the files
            }
            else
            {
                sb.AppendLine(part.ToString());
            }

        return (sb.ToString(), files);
    }

    public List<KeyValuePair<string, string>> GenerateCode(ParsedTransactionSet parsed, string baseNamespace, string version)
    {
        var sb = new StringBuilder();
        sb.AppendLine("using Eddy.Core.Attributes;");
        sb.AppendLine("using Eddy.Core.Validation;");
        sb.AppendLine($"using Eddy.x12.Models.v{version};");
        var childFileNamespace = $"{baseNamespace}.v{version}._{parsed.SegmentType}";
        sb.AppendLine($"using {childFileNamespace};");
        
        sb.AppendLine();
        sb.AppendLine();
        sb.AppendLine($"namespace {baseNamespace}.v{version};");

        sb.AppendLine($"public class Edi{parsed.ClassName} {{");

        var header = GenerateSection(parsed.Header, childFileNamespace);
        var detail = GenerateSection(parsed.Detail, childFileNamespace);
        var summary= GenerateSection(parsed.Summary, childFileNamespace);

        sb.AppendLine(header.code);
        sb.AppendLine("\t#Details");
        sb.AppendLine(detail.code);
        sb.AppendLine("\t#Summary");
        sb.AppendLine(summary.code);

        sb.AppendLine("}");

        var result = new List<KeyValuePair<string, string>>();
        result.Add(new KeyValuePair<string, string>("Edi" + parsed.ClassName, sb.ToString()));
        result.AddRange(header.files);
        result.AddRange(detail.files);
        result.AddRange(summary.files);
        return result;
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