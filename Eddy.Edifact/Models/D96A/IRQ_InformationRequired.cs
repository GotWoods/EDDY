using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("IRQ")]
public class IRQ_InformationRequired : EdifactSegment
{
	[Position(1)]
	public C333_InformationRequest InformationRequest { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IRQ_InformationRequired>(this);
		validator.Required(x=>x.InformationRequest);
		return validator.Results;
	}
}
