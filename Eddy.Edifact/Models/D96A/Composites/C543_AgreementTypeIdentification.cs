using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C543")]
public class C543_AgreementTypeIdentification : EdifactComponent
{
	[Position(1)]
	public string AgreementTypeQualifier { get; set; }

	[Position(2)]
	public string AgreementTypeCoded { get; set; }

	[Position(3)]
	public string CodeListQualifier { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(5)]
	public string AgreementTypeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C543_AgreementTypeIdentification>(this);
		validator.Required(x=>x.AgreementTypeQualifier);
		validator.Length(x => x.AgreementTypeQualifier, 1, 3);
		validator.Length(x => x.AgreementTypeCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.AgreementTypeDescription, 1, 70);
		return validator.Results;
	}
}
