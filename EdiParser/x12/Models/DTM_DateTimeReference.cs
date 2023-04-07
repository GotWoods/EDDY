using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("DTM")]
public class DTM_DateTimeReference : EdiX12Segment
{
    [Position(01)]
    public string DateTimeQualifier { get; set; }

    [Position(02)]
    public string Date { get; set; }

    [Position(03)]
    public string Time { get; set; }

    [Position(04)]
    public string TimeCode { get; set; }

    [Position(05)]
    public string DateTimePeriodFormatQualifier { get; set; }

    [Position(06)]
    public string DateTimePeriod { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<DTM_DateTimeReference>(this);
        validator.Required(x => x.DateTimeQualifier);
        validator.ARequiresB(x => x.TimeCode, x => x.Time);
        validator.IfOneIsFilled_AllAreRequired(x => x.DateTimePeriodFormatQualifier, x => x.DateTimePeriod);
        validator.Length(x => x.DateTimeQualifier, 3);
        validator.Length(x => x.Date, 8);
        validator.Length(x => x.Time, 4, 8);
        validator.Length(x => x.TimeCode, 2);
        validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
        validator.Length(x => x.DateTimePeriod, 1, 35);
        return validator.Results;
    }
}