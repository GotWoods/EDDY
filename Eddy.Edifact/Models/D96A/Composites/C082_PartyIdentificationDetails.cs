using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C082")]
public class C082_PartyIdentificationDetails : EdifactComponent
{
	[Position(1)]
	public string PartyIdIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C082_PartyIdentificationDetails>(this);
		validator.Required(x=>x.PartyIdIdentification);
		validator.Length(x => x.PartyIdIdentification, 1, 35);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
