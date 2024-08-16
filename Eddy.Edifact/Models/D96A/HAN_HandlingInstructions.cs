using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("HAN")]
public class HAN_HandlingInstructions : EdifactSegment
{
	[Position(1)]
	public C524_HandlingInstructions HandlingInstructions { get; set; }

	[Position(2)]
	public C218_HazardousMaterial HazardousMaterial { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HAN_HandlingInstructions>(this);
		return validator.Results;
	}
}
