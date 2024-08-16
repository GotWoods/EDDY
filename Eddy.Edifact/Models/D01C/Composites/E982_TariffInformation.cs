using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("E982")]
public class E982_TariffInformation : EdifactComponent
{
	[Position(1)]
	public string RateTypeIdentifier { get; set; }

	[Position(2)]
	public string MonetaryAmount { get; set; }

	[Position(3)]
	public string CurrencyIdentificationCode { get; set; }

	[Position(4)]
	public string RatePlanCode { get; set; }

	[Position(5)]
	public string MonetaryAmountTypeCodeQualifier { get; set; }

	[Position(6)]
	public string PeriodCountQuantity { get; set; }

	[Position(7)]
	public string PriceChangeTypeCode { get; set; }

	[Position(8)]
	public string TotalMonetaryAmount { get; set; }

	[Position(9)]
	public string Date { get; set; }

	[Position(10)]
	public string Date2 { get; set; }

	[Position(11)]
	public string SpecialConditionCode { get; set; }

	[Position(12)]
	public string Quantity { get; set; }

	[Position(13)]
	public string StatusDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E982_TariffInformation>(this);
		validator.Length(x => x.RateTypeIdentifier, 1, 20);
		validator.Length(x => x.MonetaryAmount, 1, 35);
		validator.Length(x => x.CurrencyIdentificationCode, 1, 3);
		validator.Length(x => x.RatePlanCode, 1, 3);
		validator.Length(x => x.MonetaryAmountTypeCodeQualifier, 1, 3);
		validator.Length(x => x.PeriodCountQuantity, 1, 3);
		validator.Length(x => x.PriceChangeTypeCode, 1, 3);
		validator.Length(x => x.TotalMonetaryAmount, 1, 20);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.Date2, 1, 14);
		validator.Length(x => x.SpecialConditionCode, 1, 3);
		validator.Length(x => x.Quantity, 1, 35);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		return validator.Results;
	}
}
