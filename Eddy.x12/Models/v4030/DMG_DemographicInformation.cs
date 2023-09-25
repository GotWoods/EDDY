using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

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
	public C056_CompositeRaceOrEthnicityInformation CompositeRaceOrEthnicityInformation { get; set; }

	[Position(06)]
	public string CitizenshipStatusCode { get; set; }

	[Position(07)]
	public string CountryCode { get; set; }

	[Position(08)]
	public string BasisOfVerificationCode { get; set; }

	[Position(09)]
	public decimal? Quantity { get; set; }

	[Position(10)]
	public string CodeListQualifierCode { get; set; }

	[Position(11)]
	public string IndustryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DMG_DemographicInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.CodeListQualifierCode, x=>x.IndustryCode);
		validator.ARequiresB(x=>x.IndustryCode, x=>x.CompositeRaceOrEthnicityInformation);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.GenderCode, 1);
		validator.Length(x => x.MaritalStatusCode, 1);
		validator.Length(x => x.CitizenshipStatusCode, 1, 2);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.BasisOfVerificationCode, 1, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.CodeListQualifierCode, 1, 3);
		validator.Length(x => x.IndustryCode, 1, 30);
		return validator.Results;
	}
}
