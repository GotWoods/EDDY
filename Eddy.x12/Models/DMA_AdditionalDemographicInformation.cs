using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

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

	[Position(10)]
	public string CityName { get; set; }

	[Position(11)]
	public string Color { get; set; }

	[Position(12)]
	public string Color2 { get; set; }

	[Position(13)]
	public string MeasurementUnitQualifier { get; set; }

	[Position(14)]
	public decimal? Height { get; set; }

	[Position(15)]
	public string WeightUnitCode { get; set; }

	[Position(16)]
	public decimal? Weight { get; set; }

	[Position(17)]
	public string Description { get; set; }

	[Position(18)]
	public string CountryCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DMA_AdditionalDemographicInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentification2, x=>x.StateOrProvinceCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeForLicensingCertificationRegistrationOrAccreditationAgency, x=>x.CountryCode);
		validator.ARequiresB(x=>x.LanguageCode, x=>x.CountryCode);
		validator.ARequiresB(x=>x.StatusCode, x=>x.ReferenceIdentification2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.MeasurementUnitQualifier, x=>x.Height);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightUnitCode, x=>x.Weight);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.StateOrProvinceCode2, 2);
		validator.Length(x => x.ApplicantTypeCode, 1);
		validator.Length(x => x.CodeForLicensingCertificationRegistrationOrAccreditationAgency, 1, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.LanguageCode, 2, 3);
		validator.Length(x => x.StatusCode, 2);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.Color, 1, 10);
		validator.Length(x => x.Color2, 1, 10);
		validator.Length(x => x.MeasurementUnitQualifier, 1);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.CountryCode2, 2, 3);
		return validator.Results;
	}
}
