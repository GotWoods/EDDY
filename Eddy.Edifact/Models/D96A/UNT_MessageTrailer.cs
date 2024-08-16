using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("UNT")]
public class UNT_MessageTrailer : EdifactSegment
{
	[Position(1)]
	public string NumberOfSegmentsInTheMessage { get; set; }

	[Position(2)]
	public string MessageReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UNT_MessageTrailer>(this);
		validator.Required(x=>x.NumberOfSegmentsInTheMessage);
		validator.Required(x=>x.MessageReferenceNumber);
		validator.Length(x => x.NumberOfSegmentsInTheMessage, 1, 6);
		validator.Length(x => x.MessageReferenceNumber, 1, 14);
		return validator.Results;
	}
}
