using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C815")]
public class C815_AdditionalSafetyInformation : EdifactComponent
{
	[Position(1)]
	public string AdditionalSafetyInformationDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string AdditionalSafetyInformationDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C815_AdditionalSafetyInformation>(this);
		validator.Required(x=>x.AdditionalSafetyInformationDescriptionCode);
		validator.Length(x => x.AdditionalSafetyInformationDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.AdditionalSafetyInformationDescription, 1, 35);
		return validator.Results;
	}
}
