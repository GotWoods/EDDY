using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("UNH")]
public class UNH_MessageHeader : EdifactSegment
{
	[Position(1)]
	public string MessageReferenceNumber { get; set; }

	[Position(2)]
	public S009_MessageIdentifier MessageIdentifier { get; set; }

	[Position(3)]
	public string CommonAccessReference { get; set; }

	[Position(4)]
	public S010_StatusOfTheTransfer StatusOfTheTransfer { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UNH_MessageHeader>(this);
		validator.Required(x=>x.MessageReferenceNumber);
		validator.Required(x=>x.MessageIdentifier);
		validator.Length(x => x.MessageReferenceNumber, 1, 14);
		validator.Length(x => x.CommonAccessReference, 1, 35);
		return validator.Results;
	}
}
