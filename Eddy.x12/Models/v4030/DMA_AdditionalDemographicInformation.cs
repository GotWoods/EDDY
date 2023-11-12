using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("DMA")]
public class DMA_AdditionalDemographicInformation : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public string StateOrProvinceCode { get; set; }

	[Position(03)]
	public string ReferenceIdentification2 { get; set; }

	[Position(04)]
	public string StateOrProvinceCode2 { get; set; }

	[Position(05)]
	public string ApplicantTypeCode { get; set; }

	[Position(06)]
	public string CodeForLicensingCertificationRegistrationOrAccreditationAgency { get; set; }

	[Position(07)]
	public string CountryCode { get; set; }

	[Position(08)]
	public string LanguageCode { get; set; }

	[Position(09)]
	public string StatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DMA_AdditionalDemographicInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentification2, x=>x.StateOrProvinceCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeForLicensingCertificationRegistrationOrAccreditationAgency, x=>x.CountryCode);
		validator.ARequiresB(x=>x.LanguageCode, x=>x.CountryCode);
		validator.ARequiresB(x=>x.StatusCode, x=>x.ReferenceIdentification2);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.ApplicantTypeCode, 1);
		validator.Length(x => x.CodeForLicensingCertificationRegistrationOrAccreditationAgency, 1);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.LanguageCode, 2, 3);
		validator.Length(x => x.StatusCode, 2);
		return validator.Results;
	}
}
