using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S500")]
public class S500_SecurityIdentificationDetails : EdifactComponent
{
	[Position(1)]
	public string SecurityPartyQualifier { get; set; }

	[Position(2)]
	public string KeyName { get; set; }

	[Position(3)]
	public string SecurityPartyIdentification { get; set; }

	[Position(4)]
	public string SecurityPartyCodeListQualifier { get; set; }

	[Position(5)]
	public string SecurityPartyCodeListResponsibleAgencyCoded { get; set; }

	[Position(6)]
	public string SecurityPartyName { get; set; }

	[Position(7)]
	public string SecurityPartyName2 { get; set; }

	[Position(8)]
	public string SecurityPartyName3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S500_SecurityIdentificationDetails>(this);
		validator.Required(x=>x.SecurityPartyQualifier);
		validator.Length(x => x.SecurityPartyQualifier, 1, 3);
		validator.Length(x => x.KeyName, 1, 35);
		validator.Length(x => x.SecurityPartyIdentification, 1, 512);
		validator.Length(x => x.SecurityPartyCodeListQualifier, 1, 3);
		validator.Length(x => x.SecurityPartyCodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.SecurityPartyName, 1, 35);
		validator.Length(x => x.SecurityPartyName2, 1, 35);
		validator.Length(x => x.SecurityPartyName3, 1, 35);
		return validator.Results;
	}
}
