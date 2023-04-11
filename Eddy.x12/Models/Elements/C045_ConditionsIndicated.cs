using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C045")]
public class C045_ConditionsIndicated : EdiX12Component
{
    [Position(00)]
    public string ConditionIndicatorCode { get; set; }

    [Position(01)]
    public string ConditionIndicatorCode2 { get; set; }

    [Position(02)]
    public string ConditionIndicatorCode3 { get; set; }

    [Position(03)]
    public string ConditionIndicatorCode4 { get; set; }

    [Position(04)]
    public string ConditionIndicatorCode5 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C045_ConditionsIndicated>(this);
        validator.Required(x => x.ConditionIndicatorCode);
        validator.Length(x => x.ConditionIndicatorCode, 2, 3);
        validator.Length(x => x.ConditionIndicatorCode2, 2, 3);
        validator.Length(x => x.ConditionIndicatorCode3, 2, 3);
        validator.Length(x => x.ConditionIndicatorCode4, 2, 3);
        validator.Length(x => x.ConditionIndicatorCode5, 2, 3);
        return validator.Results;
    }
}