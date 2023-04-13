using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("L8")]
public class L8_LineItemSubtotal : EdiX12Segment
{
	[Position(01)]
	public decimal? BilledRatedAsQuantity { get; set; }

	[Position(02)]
	public string BilledRatedAsQualifier { get; set; }

	[Position(03)]
	public decimal? Weight { get; set; }

	[Position(04)]
	public string WeightUnitCode { get; set; }

	[Position(05)]
	public string WeightQualifier { get; set; }

	[Position(06)]
	public decimal? FreightRate { get; set; }

	[Position(07)]
	public string RateValueQualifier { get; set; }

	[Position(08)]
	public string Amount { get; set; }

	[Position(09)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	[Position(10)]
	public string SpecialChargeDescription { get; set; }

	[Position(11)]
	public string ChargeMethodOfPaymentCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L8_LineItemSubtotal>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.BilledRatedAsQuantity, x=>x.BilledRatedAsQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.FreightRate, x=>x.RateValueQualifier);
		validator.ARequiresB(x=>x.SpecialChargeOrAllowanceCode, x=>x.Amount);
		validator.Length(x => x.BilledRatedAsQuantity, 1, 11);
		validator.Length(x => x.BilledRatedAsQualifier, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.WeightUnitCode, 1);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.FreightRate, 1, 15);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		validator.Length(x => x.SpecialChargeDescription, 2, 25);
		validator.Length(x => x.ChargeMethodOfPaymentCode, 1);
		return validator.Results;
	}
}
