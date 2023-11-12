using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5010;

[Segment("L1")]
public class L1_RateAndCharges : EdiX12Segment
{
	[Position(01)]
	public int? LadingLineItemNumber { get; set; }

	[Position(02)]
	public decimal? FreightRate { get; set; }

	[Position(03)]
	public string RateValueQualifier { get; set; }

	[Position(04)]
	public string AmountCharged { get; set; }

	[Position(05)]
	public string Advances { get; set; }

	[Position(06)]
	public string PrepaidAmount { get; set; }

	[Position(07)]
	public string RateCombinationPointCode { get; set; }

	[Position(08)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	[Position(09)]
	public string RateClassCode { get; set; }

	[Position(10)]
	public string EntitlementCode { get; set; }

	[Position(11)]
	public string ChargeMethodOfPayment { get; set; }

	[Position(12)]
	public string SpecialChargeDescription { get; set; }

	[Position(13)]
	public string TariffApplicationCode { get; set; }

	[Position(14)]
	public string DeclaredValue { get; set; }

	[Position(15)]
	public string RateValueQualifier2 { get; set; }

	[Position(16)]
	public string LadingLiabilityCode { get; set; }

	[Position(17)]
	public decimal? BilledRatedAsQuantity { get; set; }

	[Position(18)]
	public string BilledRatedAsQualifier { get; set; }

	[Position(19)]
	public decimal? PercentageAsDecimal { get; set; }

	[Position(20)]
	public string CurrencyCode { get; set; }

	[Position(21)]
	public string Amount { get; set; }

	[Position(22)]
	public decimal? LadingValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L1_RateAndCharges>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.FreightRate, x=>x.RateValueQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DeclaredValue, x=>x.RateValueQualifier2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.BilledRatedAsQuantity, x=>x.BilledRatedAsQualifier);
		validator.Length(x => x.LadingLineItemNumber, 1, 3);
		validator.Length(x => x.FreightRate, 1, 9);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.AmountCharged, 1, 15);
		validator.Length(x => x.Advances, 1, 9);
		validator.Length(x => x.PrepaidAmount, 1, 15);
		validator.Length(x => x.RateCombinationPointCode, 3, 9);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		validator.Length(x => x.RateClassCode, 1, 3);
		validator.Length(x => x.EntitlementCode, 1);
		validator.Length(x => x.ChargeMethodOfPayment, 1);
		validator.Length(x => x.SpecialChargeDescription, 2, 25);
		validator.Length(x => x.TariffApplicationCode, 1);
		validator.Length(x => x.DeclaredValue, 2, 12);
		validator.Length(x => x.RateValueQualifier2, 2);
		validator.Length(x => x.LadingLiabilityCode, 1);
		validator.Length(x => x.BilledRatedAsQuantity, 1, 11);
		validator.Length(x => x.BilledRatedAsQualifier, 2);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.LadingValue, 2, 9);
		return validator.Results;
	}
}
