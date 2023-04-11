using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C074")]
public class C074_CompositeDateTimePeriod : EdiX12Component
{
    [Position(00)]
    public string DateTimePeriod { get; set; }

    [Position(01)]
    public string DateTimePeriod2 { get; set; }

    [Position(02)]
    public string DateTimePeriod3 { get; set; }

    [Position(03)]
    public string DateTimePeriod4 { get; set; }

    [Position(04)]
    public string DateTimePeriod5 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C074_CompositeDateTimePeriod>(this);
        validator.Required(x => x.DateTimePeriod);
        validator.ARequiresB(x => x.DateTimePeriod3, x => x.DateTimePeriod2);
        validator.ARequiresB(x => x.DateTimePeriod4, x => x.DateTimePeriod3);
        validator.ARequiresB(x => x.DateTimePeriod5, x => x.DateTimePeriod4);
        validator.Length(x => x.DateTimePeriod, 1, 35);
        validator.Length(x => x.DateTimePeriod2, 1, 35);
        validator.Length(x => x.DateTimePeriod3, 1, 35);
        validator.Length(x => x.DateTimePeriod4, 1, 35);
        validator.Length(x => x.DateTimePeriod5, 1, 35);
        return validator.Results;
    }
}