using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070.Composites;

namespace Eddy.x12.Models.v3070;

[Segment("PAY")]
public class PAY_AdjustablePaymentDescription : EdiX12Segment
{
	[Position(01)]
	public string PaymentAdjustmentCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? Percent { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(05)]
	public decimal? Percent2 { get; set; }

	[Position(06)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(07)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(08)]
	public decimal? Quantity { get; set; }

	[Position(09)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure2 { get; set; }

	[Position(10)]
	public decimal? Quantity2 { get; set; }

	[Position(11)]
	public decimal? Percent3 { get; set; }

	[Position(12)]
	public decimal? Percent4 { get; set; }

	[Position(13)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(14)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(15)]
	public decimal? Quantity3 { get; set; }

	[Position(16)]
	public decimal? Percent5 { get; set; }

	[Position(17)]
	public decimal? MonetaryAmount5 { get; set; }

	[Position(18)]
	public string NegativeAmortizationQualifier { get; set; }

	[Position(19)]
	public decimal? Percent6 { get; set; }

	[Position(20)]
	public decimal? MonetaryAmount6 { get; set; }

	[Position(21)]
	public string NegativeAmortizationCapSourceCode { get; set; }

	[Position(22)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PAY_AdjustablePaymentDescription>(this);
		validator.Required(x=>x.PaymentAdjustmentCode);
		validator.Length(x => x.PaymentAdjustmentCode, 1);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.Percent2, 1, 10);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Percent3, 1, 10);
		validator.Length(x => x.Percent4, 1, 10);
		validator.Length(x => x.MonetaryAmount4, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.Percent5, 1, 10);
		validator.Length(x => x.MonetaryAmount5, 1, 15);
		validator.Length(x => x.NegativeAmortizationQualifier, 1);
		validator.Length(x => x.Percent6, 1, 10);
		validator.Length(x => x.MonetaryAmount6, 1, 15);
		validator.Length(x => x.NegativeAmortizationCapSourceCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		return validator.Results;
	}
}
