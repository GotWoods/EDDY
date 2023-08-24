using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("AOC")]
public class AOC_AnimalOffspringCounts : EdiX12Segment
{
    [Position(01)]
    public string OffspringCountCode { get; set; }

    [Position(02)]
    public int? Count { get; set; }

    [Position(03)]
    public string Date { get; set; }

    [Position(04)]
    public int? TestPeriodOrIntervalValue { get; set; }

    [Position(05)]
    public string UnitOfTimePeriodOrIntervalCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<AOC_AnimalOffspringCounts>(this);
        validator.Required(x => x.OffspringCountCode);
        validator.Required(x => x.Count);
        validator.AtLeastOneIsRequired(x => x.Date, x => x.TestPeriodOrIntervalValue);
        validator.IfOneIsFilled_AllAreRequired(x => x.TestPeriodOrIntervalValue, x => x.UnitOfTimePeriodOrIntervalCode);
        validator.Length(x => x.OffspringCountCode, 2);
        validator.Length(x => x.Count, 1, 9);
        validator.Length(x => x.Date, 8);
        validator.Length(x => x.TestPeriodOrIntervalValue, 1, 6);
        validator.Length(x => x.UnitOfTimePeriodOrIntervalCode, 2);
        return validator.Results;
    }
}
