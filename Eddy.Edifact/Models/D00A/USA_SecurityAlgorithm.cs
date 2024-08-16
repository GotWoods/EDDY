using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("USA")]
public class USA_SecurityAlgorithm : EdifactSegment
{
	[Position(1)]
	public S502_SecurityAlgorithm SecurityAlgorithm { get; set; }

	[Position(2)]
	public S503_AlgorithmParameter AlgorithmParameter { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USA_SecurityAlgorithm>(this);
		validator.Required(x=>x.SecurityAlgorithm);
		return validator.Results;
	}
}
