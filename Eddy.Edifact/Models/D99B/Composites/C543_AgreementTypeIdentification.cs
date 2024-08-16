using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C543")]
public class C543_AgreementTypeIdentification : EdifactComponent
{
	[Position(1)]
	public string AgreementTypeCodeQualifier { get; set; }

	[Position(2)]
	public string AgreementTypeDescriptionCode { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(5)]
	public string AgreementTypeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C543_AgreementTypeIdentification>(this);
		validator.Required(x=>x.AgreementTypeCodeQualifier);
		validator.Length(x => x.AgreementTypeCodeQualifier, 1, 3);
		validator.Length(x => x.AgreementTypeDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.AgreementTypeDescription, 1, 70);
		return validator.Results;
	}
}
