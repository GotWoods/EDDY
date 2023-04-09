using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models.Elements;

[Segment("C002")]
public class C002_ActionsIndicated : EdiX12Component
{
    [Position(00)]
    public string PaperworkReportActionCode { get; set; }

    [Position(01)]
    public string PaperworkReportActionCode2 { get; set; }

    [Position(02)]
    public string PaperworkReportActionCode3 { get; set; }

    [Position(03)]
    public string PaperworkReportActionCode4 { get; set; }

    [Position(04)]
    public string PaperworkReportActionCode5 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C002_ActionsIndicated>(this);
        validator.Required(x => x.PaperworkReportActionCode);
        validator.Length(x => x.PaperworkReportActionCode, 1, 2);
        validator.Length(x => x.PaperworkReportActionCode2, 1, 2);
        validator.Length(x => x.PaperworkReportActionCode3, 1, 2);
        validator.Length(x => x.PaperworkReportActionCode4, 1, 2);
        validator.Length(x => x.PaperworkReportActionCode5, 1, 2);
        return validator.Results;
    }
}