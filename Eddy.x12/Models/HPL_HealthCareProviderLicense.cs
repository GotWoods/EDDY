using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("HPL")]
public class HPL_HealthCareProviderLicense : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string StatusCode { get; set; }

	[Position(04)]
	public string StateOrProvinceCode { get; set; }

	[Position(05)]
	public string Description { get; set; }

	[Position(06)]
	public string CodeForLicensingCertificationRegistrationOrAccreditationAgency { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HPL_HealthCareProviderLicense>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.AtLeastOneIsRequired(x=>x.ReferenceIdentification, x=>x.CodeForLicensingCertificationRegistrationOrAccreditationAgency);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.StatusCode, 2);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.CodeForLicensingCertificationRegistrationOrAccreditationAgency, 1, 2);
		return validator.Results;
	}
}
