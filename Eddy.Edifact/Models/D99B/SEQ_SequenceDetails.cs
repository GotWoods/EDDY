using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("SEQ")]
public class SEQ_SequenceDetails : EdifactSegment
{
	[Position(1)]
	public string ActionRequestNotificationDescriptionCode { get; set; }

	[Position(2)]
	public C286_SequenceInformation SequenceInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SEQ_SequenceDetails>(this);
		validator.Length(x => x.ActionRequestNotificationDescriptionCode, 1, 3);
		return validator.Results;
	}
}
