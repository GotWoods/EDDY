using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C836")]
public class C836_ClinicalInformationDetails : EdifactComponent
{
	[Position(1)]
	public string ClinicalInformationDescriptionIdentifier { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ClinicalInformationDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C836_ClinicalInformationDetails>(this);
		validator.Length(x => x.ClinicalInformationDescriptionIdentifier, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ClinicalInformationDescription, 1, 70);
		return validator.Results;
	}
}
