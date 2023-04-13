using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("IND")]
public class IND_AdditionalIndividualDemographicInformation : EdiX12Segment
{
	[Position(01)]
	public string CountryCode { get; set; }

	[Position(02)]
	public string StateOrProvinceCode { get; set; }

	[Position(03)]
	public string CountyDesignatorCode { get; set; }

	[Position(04)]
	public string CityName { get; set; }

	[Position(05)]
	public string LanguageCode { get; set; }

	[Position(06)]
	public string LanguageProficiencyIndicatorCode { get; set; }

	[Position(07)]
	public string LanguageCode2 { get; set; }

	[Position(08)]
	public string LanguageCode3 { get; set; }

	[Position(09)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(10)]
	public string IdentificationCode { get; set; }

	[Position(11)]
	public string IdentificationCodeQualifier2 { get; set; }

	[Position(12)]
	public string IdentificationCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IND_AdditionalIndividualDemographicInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IdentificationCodeQualifier2, x=>x.IdentificationCode2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountyDesignatorCode, 5);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.LanguageCode, 2, 3);
		validator.Length(x => x.LanguageProficiencyIndicatorCode, 1);
		validator.Length(x => x.LanguageCode2, 2, 3);
		validator.Length(x => x.LanguageCode3, 2, 3);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.IdentificationCodeQualifier2, 1, 2);
		validator.Length(x => x.IdentificationCode2, 2, 80);
		return validator.Results;
	}
}
