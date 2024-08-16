using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E982")]
public class E982_TariffInformation : EdifactComponent
{
	[Position(1)]
	public string RateTypeIdentification { get; set; }

	[Position(2)]
	public string MonetaryAmountValue { get; set; }

	[Position(3)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(4)]
	public string RatePlanCoded { get; set; }

	[Position(5)]
	public string MonetaryAmountTypeCodeQualifier { get; set; }

	[Position(6)]
	public string PeriodCountQuantity { get; set; }

	[Position(7)]
	public string PriceChangeIndicatorCoded { get; set; }

	[Position(8)]
	public string TotalMonetaryAmount { get; set; }

	[Position(9)]
	public string DateValue { get; set; }

	[Position(10)]
	public string DateValue2 { get; set; }

	[Position(11)]
	public string SpecialConditionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E982_TariffInformation>(this);
		validator.Length(x => x.RateTypeIdentification, 1, 20);
		validator.Length(x => x.MonetaryAmountValue, 1, 35);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.RatePlanCoded, 1, 3);
		validator.Length(x => x.MonetaryAmountTypeCodeQualifier, 1, 3);
		validator.Length(x => x.PeriodCountQuantity, 1, 3);
		validator.Length(x => x.PriceChangeIndicatorCoded, 1, 3);
		validator.Length(x => x.TotalMonetaryAmount, 1, 20);
		validator.Length(x => x.DateValue, 1, 14);
		validator.Length(x => x.DateValue2, 1, 14);
		validator.Length(x => x.SpecialConditionCode, 1, 3);
		return validator.Results;
	}
}
