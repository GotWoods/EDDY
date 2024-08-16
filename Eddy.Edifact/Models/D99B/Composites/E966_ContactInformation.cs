using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E966")]
public class E966_ContactInformation : EdifactComponent
{
	[Position(1)]
	public string PartyFunctionCodeQualifier { get; set; }

	[Position(2)]
	public string CommunicationNumber { get; set; }

	[Position(3)]
	public string CommunicationMediumTypeCode { get; set; }

	[Position(4)]
	public string PartyName { get; set; }

	[Position(5)]
	public string ReferenceIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E966_ContactInformation>(this);
		validator.Required(x=>x.PartyFunctionCodeQualifier);
		validator.Required(x=>x.CommunicationNumber);
		validator.Length(x => x.PartyFunctionCodeQualifier, 1, 3);
		validator.Length(x => x.CommunicationNumber, 1, 512);
		validator.Length(x => x.CommunicationMediumTypeCode, 1, 3);
		validator.Length(x => x.PartyName, 1, 35);
		validator.Length(x => x.ReferenceIdentifier, 1, 35);
		return validator.Results;
	}
}
