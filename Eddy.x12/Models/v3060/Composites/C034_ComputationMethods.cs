using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060.Composites;

[Segment("C034")]
public class C034_ComputationMethods : EdiX12Component
{
	[Position(00)]
	public string AssuranceAlgorithm { get; set; }

	[Position(01)]
	public string HashingAlgorithm { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C034_ComputationMethods>(this);
		validator.Required(x=>x.AssuranceAlgorithm);
		validator.Required(x=>x.HashingAlgorithm);
		validator.Length(x => x.AssuranceAlgorithm, 3);
		validator.Length(x => x.HashingAlgorithm, 3);
		return validator.Results;
	}
}
