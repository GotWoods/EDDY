using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("ADI")]
public class ADI_AnimalDisposition : EdiX12Segment
{
    [Position(01)] public string AnimalDispositionCode { get; set; }

    [Position(02)] public string Date { get; set; }

    [Position(03)] public int? TestPeriodOrIntervalValue { get; set; }

    [Position(04)] public string UnitOfTimePeriodOrIntervalCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<ADI_AnimalDisposition>(this);
        validator.Required(x => x.AnimalDispositionCode);
        validator.Required(x => x.Date);
        validator.IfOneIsFilled_AllAreRequired(x => x.TestPeriodOrIntervalValue, x => x.UnitOfTimePeriodOrIntervalCode);
        validator.Length(x => x.AnimalDispositionCode, 2);
        validator.Length(x => x.Date, 8);
        validator.Length(x => x.TestPeriodOrIntervalValue, 1, 6);
        validator.Length(x => x.UnitOfTimePeriodOrIntervalCode, 2);
        return validator.Results;
    }
}