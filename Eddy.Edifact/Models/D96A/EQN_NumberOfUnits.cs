using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("EQN")]
public class EQN_NumberOfUnits : EdifactSegment
{
	[Position(1)]
	public C523_NumberOfUnitDetails NumberOfUnitDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EQN_NumberOfUnits>(this);
		validator.Required(x=>x.NumberOfUnitDetails);
		return validator.Results;
	}
}
