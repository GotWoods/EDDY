using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Models.D06A;

[Segment("FRM")]
public class FRM_FollowUpAction : EdifactSegment
{
	[Position(1)]
	public string ObjectIdentifier { get; set; }

	[Position(2)]
	public string StatusReasonDescriptionCode { get; set; }

	[Position(3)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FRM_FollowUpAction>(this);
		validator.Required(x=>x.ObjectIdentifier);
		validator.Required(x=>x.StatusReasonDescriptionCode);
		validator.Length(x => x.ObjectIdentifier, 1, 35);
		validator.Length(x => x.StatusReasonDescriptionCode, 1, 3);
		validator.Length(x => x.ActionCode, 1, 3);
		return validator.Results;
	}
}
