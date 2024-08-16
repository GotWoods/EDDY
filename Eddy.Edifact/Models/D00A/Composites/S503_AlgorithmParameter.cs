using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S503")]
public class S503_AlgorithmParameter : EdifactComponent
{
	[Position(1)]
	public string AlgorithmParameterQualifier { get; set; }

	[Position(2)]
	public string AlgorithmParameterValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S503_AlgorithmParameter>(this);
		validator.Required(x=>x.AlgorithmParameterQualifier);
		validator.Required(x=>x.AlgorithmParameterValue);
		validator.Length(x => x.AlgorithmParameterQualifier, 1, 3);
		validator.Length(x => x.AlgorithmParameterValue, 1, 512);
		return validator.Results;
	}
}
