using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UNT")]
public class UNT_MessageTrailer : EdifactSegment
{
	[Position(1)]
	public string NumberOfSegmentsInAMessage { get; set; }

	[Position(2)]
	public string MessageReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UNT_MessageTrailer>(this);
		validator.Required(x=>x.NumberOfSegmentsInAMessage);
		validator.Required(x=>x.MessageReferenceNumber);
		validator.Length(x => x.NumberOfSegmentsInAMessage, 1, 10);
		validator.Length(x => x.MessageReferenceNumber, 1, 14);
		return validator.Results;
	}
}
