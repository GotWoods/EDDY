using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("CNT")]
public class CNT_ControlTotal : EdifactSegment
{
	[Position(1)]
	public C270_Control Control { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CNT_ControlTotal>(this);
		validator.Required(x=>x.Control);
		return validator.Results;
	}
}
