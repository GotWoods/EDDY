using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

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
	public string LicensingAgencyCode { get; set; }

	[Position(07)]
	public string CountryCode { get; set; }

	[Position(08)]
	public string LanguageCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DMA_AdditionalDemographicInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentification2, x=>x.StateOrProvinceCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LicensingAgencyCode, x=>x.CountryCode);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.ReferenceIdentification2, 1, 30);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.ApplicantTypeCode, 1);
		validator.Length(x => x.LicensingAgencyCode, 1);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.LanguageCode, 2, 3);
		return validator.Results;
	}
}
