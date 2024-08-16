using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UIT")]
public class UIT_InteractiveMessageTrailer : EdifactSegment
{
	[Position(1)]
	public string InteractiveMessageReferenceNumber { get; set; }

	[Position(2)]
	public string NumberOfSegmentsInAMessage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UIT_InteractiveMessageTrailer>(this);
		validator.Length(x => x.InteractiveMessageReferenceNumber, 1, 35);
		validator.Length(x => x.NumberOfSegmentsInAMessage, 1, 10);
		return validator.Results;
	}
}
