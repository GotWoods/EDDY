using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("SEQ")]
public class SEQ_SequenceDetails : EdifactSegment
{
	[Position(1)]
	public string StatusIndicatorCoded { get; set; }

	[Position(2)]
	public C286_SequenceInformation SequenceInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SEQ_SequenceDetails>(this);
		validator.Length(x => x.StatusIndicatorCoded, 1, 3);
		return validator.Results;
	}
}
