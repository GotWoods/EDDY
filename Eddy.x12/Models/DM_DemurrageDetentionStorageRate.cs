using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("DM")]
public class DM_DemurrageDetentionStorageRate : EdiX12Segment
{
	[Position(01)]
	public string GeographyQualifierCode { get; set; }

	[Position(02)]
	public string RateValueQualifier { get; set; }

	[Position(03)]
	public string TimeQualifier { get; set; }

	[Position(04)]
	public string Time { get; set; }

	[Position(05)]
	public int? NumberOfPeriods { get; set; }

	[Position(06)]
	public string TimePeriodQualifier { get; set; }

	[Position(07)]
	public int? NumberOfPeriods2 { get; set; }

	[Position(08)]
	public decimal? Rate { get; set; }

	[Position(09)]
	public string IntermodalServiceCode { get; set; }

	[Position(10)]
	public string TariffApplicationCode { get; set; }

	[Position(11)]
	public string BillingCode { get; set; }

	[Position(12)]
	public string TimePeriodQualifier2 { get; set; }

	[Position(13)]
	public int? NumberOfPeriods3 { get; set; }

	[Position(14)]
	public int? NumberOfPeriods4 { get; set; }

	[Position(15)]
	public decimal? Rate2 { get; set; }

	[Position(16)]
	public int? NumberOfPeriods5 { get; set; }

	[Position(17)]
	public decimal? Rate3 { get; set; }

	[Position(18)]
	public int? NumberOfPeriods6 { get; set; }

	[Position(19)]
	public decimal? Rate4 { get; set; }

	[Position(20)]
	public int? NumberOfPeriods7 { get; set; }

	[Position(21)]
	public decimal? Rate5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DM_DemurrageDetentionStorageRate>(this);
		validator.Required(x=>x.GeographyQualifierCode);
		validator.Required(x=>x.RateValueQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TimeQualifier, x=>x.Time);
		validator.Required(x=>x.NumberOfPeriods);
		validator.Required(x=>x.TimePeriodQualifier);
		validator.Required(x=>x.NumberOfPeriods2);
		validator.Required(x=>x.Rate);
		validator.IfOneIsFilled_AllAreRequired(x=>x.IntermodalServiceCode, x=>x.TariffApplicationCode);
		validator.Length(x => x.GeographyQualifierCode, 1);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.TimeQualifier, 1, 2);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.NumberOfPeriods, 1, 3);
		validator.Length(x => x.TimePeriodQualifier, 1, 2);
		validator.Length(x => x.NumberOfPeriods2, 1, 3);
		validator.Length(x => x.Rate, 1, 9);
		validator.Length(x => x.IntermodalServiceCode, 1, 2);
		validator.Length(x => x.TariffApplicationCode, 1);
		validator.Length(x => x.BillingCode, 1);
		validator.Length(x => x.TimePeriodQualifier2, 1, 2);
		validator.Length(x => x.NumberOfPeriods3, 1, 3);
		validator.Length(x => x.NumberOfPeriods4, 1, 3);
		validator.Length(x => x.Rate2, 1, 9);
		validator.Length(x => x.NumberOfPeriods5, 1, 3);
		validator.Length(x => x.Rate3, 1, 9);
		validator.Length(x => x.NumberOfPeriods6, 1, 3);
		validator.Length(x => x.Rate4, 1, 9);
		validator.Length(x => x.NumberOfPeriods7, 1, 3);
		validator.Length(x => x.Rate5, 1, 9);
		return validator.Results;
	}
}
