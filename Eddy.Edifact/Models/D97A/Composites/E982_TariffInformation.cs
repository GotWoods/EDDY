using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E982")]
public class E982_TariffInformation : EdifactComponent
{
	[Position(1)]
	public string RateTypeIdentification { get; set; }

	[Position(2)]
	public string MonetaryAmount { get; set; }

	[Position(3)]
	public string CurrencyCoded { get; set; }

	[Position(4)]
	public string RatePlanCoded { get; set; }

	[Position(5)]
	public string MonetaryAmountTypeQualifier { get; set; }

	[Position(6)]
	public string NumberOfPeriods { get; set; }

	[Position(7)]
	public string PriceChangeIndicatorCoded { get; set; }

	[Position(8)]
	public string TotalMonetaryAmount { get; set; }

	[Position(9)]
	public string Date { get; set; }

	[Position(10)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E982_TariffInformation>(this);
		validator.Length(x => x.RateTypeIdentification, 1, 20);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.CurrencyCoded, 1, 3);
		validator.Length(x => x.RatePlanCoded, 1, 3);
		validator.Length(x => x.MonetaryAmountTypeQualifier, 1, 3);
		validator.Length(x => x.NumberOfPeriods, 1, 3);
		validator.Length(x => x.PriceChangeIndicatorCoded, 1, 3);
		validator.Length(x => x.TotalMonetaryAmount, 1, 20);
		validator.Length(x => x.Date, 1, 14);
		validator.Length(x => x.Date2, 1, 14);
		return validator.Results;
	}
}
