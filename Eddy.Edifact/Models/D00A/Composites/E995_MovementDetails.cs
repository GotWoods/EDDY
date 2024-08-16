using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E995")]
public class E995_MovementDetails : EdifactComponent
{
	[Position(1)]
	public string ServiceRequirementCode { get; set; }

	[Position(2)]
	public string DateValue { get; set; }

	[Position(3)]
	public string TimeValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E995_MovementDetails>(this);
		validator.Length(x => x.ServiceRequirementCode, 1, 3);
		validator.Length(x => x.DateValue, 1, 14);
		validator.Length(x => x.TimeValue, 4);
		return validator.Results;
	}
}
