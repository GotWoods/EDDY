using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("PRC")]
public class PRC_PaymentRateChange : EdiX12Segment
{
	[Position(01)]
	public string DateTimeQualifier { get; set; }

	[Position(02)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriod { get; set; }

	[Position(04)]
	public decimal? InterestRate { get; set; }

	[Position(05)]
	public decimal? InterestRate2 { get; set; }

	[Position(06)]
	public decimal? InterestRate3 { get; set; }

	[Position(07)]
	public string AmountQualifierCode { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(10)]
	public string QuantityQualifier { get; set; }

	[Position(11)]
	public decimal? Quantity { get; set; }

	[Position(12)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRC_PaymentRateChange>(this);
		validator.Required(x=>x.DateTimeQualifier);
		validator.Required(x=>x.DateTimePeriodFormatQualifier);
		validator.Required(x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.InterestRate, 1, 6);
		validator.Length(x => x.InterestRate2, 1, 6);
		validator.Length(x => x.InterestRate3, 1, 6);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
