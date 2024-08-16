using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Models.D97B;

[Segment("LKP")]
public class LKP_LevelIndication : EdifactSegment
{
	[Position(1)]
	public E778_PositionIdentification PositionIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LKP_LevelIndication>(this);
		validator.Required(x=>x.PositionIdentification);
		return validator.Results;
	}
}
