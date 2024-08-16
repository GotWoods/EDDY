using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C082")]
public class C082_PartyIdentificationDetails : EdifactComponent
{
	[Position(1)]
	public string PartyIdentifier { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C082_PartyIdentificationDetails>(this);
		validator.Required(x=>x.PartyIdentifier);
		validator.Length(x => x.PartyIdentifier, 1, 35);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
