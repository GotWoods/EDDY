using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

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

	[Position(5)]
	public S016_MessageSubsetIdentification MessageSubsetIdentification { get; set; }

	[Position(6)]
	public S017_MessageImplementationGuidelineIdentification MessageImplementationGuidelineIdentification { get; set; }

	[Position(7)]
	public S018_ScenarioIdentification ScenarioIdentification { get; set; }

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
