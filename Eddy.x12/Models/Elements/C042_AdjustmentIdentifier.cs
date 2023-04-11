using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C042")]
public class C042_AdjustmentIdentifier : EdiX12Component
{
    [Position(00)]
    public string IndustryCode { get; set; }

    [Position(01)]
    public string ReferenceIdentification { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C042_AdjustmentIdentifier>(this);
        validator.Required(x => x.IndustryCode);
        validator.Length(x => x.IndustryCode, 1, 30);
        validator.Length(x => x.ReferenceIdentification, 1, 80);
        return validator.Results;
    }
}