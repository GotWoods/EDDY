using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models.Elements;

[Segment("C034")]
public class C034_ComputationMethods : EdiX12Component
{
    [Position(00)]
    public string AssuranceAlgorithmCode { get; set; }

    [Position(01)]
    public string HashingAlgorithmCode { get; set; }

    public override ValidationResult Validate()
    {
        var validator = new BasicValidator<C034_ComputationMethods>(this);
        validator.Required(x => x.AssuranceAlgorithmCode);
        validator.Required(x => x.HashingAlgorithmCode);
        validator.Length(x => x.AssuranceAlgorithmCode, 3);
        validator.Length(x => x.HashingAlgorithmCode, 3);
        return validator.Results;
    }
}