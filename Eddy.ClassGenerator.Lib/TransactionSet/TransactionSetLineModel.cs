#nullable enable
using System.Text;
using Eddy.x12;

namespace Eddy.ClassGenerator.Lib;

public class TransactionSetLineModel : ITransactionSetModel
{
    public int Position { get; set; }
    public string SegmentType { get; set; } = string.Empty;

    public bool Required { get; set;}
    public int Max { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Min { get; set; }

    public string GenerateCode(string version, string childObjectPrefix)
    {
        //var name = Name.Substring(0, Name.IndexOf("_") - 1);
        var segment = EdiSectionParserFactory.GetSegmentFor(version, SegmentType);
        //var segmentWithoutPrefix = segment.Name.Substring(segment.Name.IndexOf("_")+1);
        var sb = new StringBuilder();
        sb.AppendLine($"\t[SectionPosition({Position})]");
        if (Max > 1)
            sb.Append($"\tpublic List<{segment.Name}> {Name} {{ get; set; }} = new();");
        else
        {
            if (Required)
                sb.Append($"\tpublic {segment.Name} {Name} {{ get; set; }} = new();");
            else
                sb.Append($"\tpublic {segment.Name}? {Name} {{ get; set; }}");
        }

        return sb.ToString();
    }
}