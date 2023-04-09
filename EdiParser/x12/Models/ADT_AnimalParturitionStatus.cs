using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

[Segment("ADT")]
public class ADT_AnimalParturitionStatus : EdiX12Segment
{
    [Position(01)] public string ParturitionStatusCode { get; set; }

    [Position(02)] public string Date { get; set; }

    [Position(03)] public int? TestPeriodOrIntervalValue { get; set; }

    [Position(04)] public string UnitOfTimePeriodOrIntervalCode { get; set; }

    [Position(05)] public string Date2 { get; set; }

    [Position(06)] public int? TestPeriodOrIntervalValue2 { get; set; }

    [Position(07)] public string UnitOfTimePeriodOrIntervalCode2 { get; set; }

    [Position(08)] public string Time { get; set; }

    [Position(09)] public int? TestPeriodOrIntervalValue3 { get; set; }

    [Position(10)] public string UnitOfTimePeriodOrIntervalCode3 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<ADT_AnimalParturitionStatus>(this);
        validator.Required(x => x.ParturitionStatusCode);
        validator.IfOneIsFilled_AllAreRequired(x => x.TestPeriodOrIntervalValue, x => x.UnitOfTimePeriodOrIntervalCode);
        validator.IfOneIsFilled_AllAreRequired(x => x.TestPeriodOrIntervalValue2, x => x.UnitOfTimePeriodOrIntervalCode2);
        validator.IfOneIsFilled_AllAreRequired(x => x.TestPeriodOrIntervalValue3, x => x.UnitOfTimePeriodOrIntervalCode3);
        validator.Length(x => x.ParturitionStatusCode, 1);
        validator.Length(x => x.Date, 8);
        validator.Length(x => x.TestPeriodOrIntervalValue, 1, 6);
        validator.Length(x => x.UnitOfTimePeriodOrIntervalCode, 2);
        validator.Length(x => x.Date2, 8);
        validator.Length(x => x.TestPeriodOrIntervalValue2, 1, 6);
        validator.Length(x => x.UnitOfTimePeriodOrIntervalCode2, 2);
        validator.Length(x => x.Time, 4, 8);
        validator.Length(x => x.TestPeriodOrIntervalValue3, 1, 6);
        validator.Length(x => x.UnitOfTimePeriodOrIntervalCode3, 2);
        return validator.Results;
    }
}