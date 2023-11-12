using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("DMG")]
public class DMG_DemographicInformation : EdiX12Segment
{
	[Position(01)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(02)]
	public string DateTimePeriod { get; set; }

	[Position(03)]
	public string GenderCode { get; set; }

	[Position(04)]
	public string MaritalStatusCode { get; set; }

	[Position(05)]
	public string RaceOrEthnicityCode { get; set; }

	[Position(06)]
	public string CitizenshipStatusCode { get; set; }

	[Position(07)]
	public string CountryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DMG_DemographicInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.GenderCode, 1);
		validator.Length(x => x.MaritalStatusCode, 1);
		validator.Length(x => x.RaceOrEthnicityCode, 1);
		validator.Length(x => x.CitizenshipStatusCode, 1, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		return validator.Results;
	}
}
