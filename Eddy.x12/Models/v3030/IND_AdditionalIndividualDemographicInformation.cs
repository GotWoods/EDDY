using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("IND")]
public class IND_AdditionalIndividualDemographicInformation : EdiX12Segment
{
	[Position(01)]
	public string CountryCode { get; set; }

	[Position(02)]
	public string StateOrProvinceCode { get; set; }

	[Position(03)]
	public string CountyDesignator { get; set; }

	[Position(04)]
	public string CityName { get; set; }

	[Position(05)]
	public string LanguageCode { get; set; }

	[Position(06)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IND_AdditionalIndividualDemographicInformation>(this);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.StateOrProvinceCode, 2);
		validator.Length(x => x.CountyDesignator, 5);
		validator.Length(x => x.CityName, 2, 30);
		validator.Length(x => x.LanguageCode, 2, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
