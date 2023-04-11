using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C052")]
public class C052_MedicareStatusCode : EdiX12Component
{
    [Position(00)]
    public string MedicarePlanCode { get; set; }

    [Position(01)]
    public string EligibilityReasonCode { get; set; }

    [Position(02)]
    public string EligibilityReasonCode2 { get; set; }

    [Position(03)]
    public string EligibilityReasonCode3 { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C052_MedicareStatusCode>(this);
        validator.Required(x => x.MedicarePlanCode);
        validator.Length(x => x.MedicarePlanCode, 1);
        validator.Length(x => x.EligibilityReasonCode, 1);
        validator.Length(x => x.EligibilityReasonCode2, 1);
        validator.Length(x => x.EligibilityReasonCode3, 1);
        return validator.Results;
    }
}