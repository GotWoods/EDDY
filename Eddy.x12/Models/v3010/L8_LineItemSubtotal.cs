using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

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
	public string WeightUnitQualifier { get; set; }

	[Position(05)]
	public string WeightQualifier { get; set; }

	[Position(06)]
	public decimal? FreightRate { get; set; }

	[Position(07)]
	public string RateValueQualifier { get; set; }

	[Position(08)]
	public string Charge { get; set; }

	[Position(09)]
	public string SpecialChargeCode { get; set; }

	[Position(10)]
	public string SpecialChargeDescription { get; set; }

	[Position(11)]
	public string ChargeMethodOfPayment { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L8_LineItemSubtotal>(this);
		validator.Length(x => x.BilledRatedAsQuantity, 1, 11);
		validator.Length(x => x.BilledRatedAsQualifier, 2);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.WeightUnitQualifier, 1);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.FreightRate, 1, 9);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.Charge, 1, 9);
		validator.Length(x => x.SpecialChargeCode, 3);
		validator.Length(x => x.SpecialChargeDescription, 2, 25);
		validator.Length(x => x.ChargeMethodOfPayment, 1);
		return validator.Results;
	}
}
