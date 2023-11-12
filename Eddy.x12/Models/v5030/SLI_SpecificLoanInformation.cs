using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("SLI")]
public class SLI_SpecificLoanInformation : EdiX12Segment
{
	[Position(01)]
	public string LoanTypeCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(04)]
	public decimal? InterestRate { get; set; }

	[Position(05)]
	public string LoanRateTypeCode { get; set; }

	[Position(06)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(07)]
	public string DateTimePeriod { get; set; }

	[Position(08)]
	public string ReferenceIdentification { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(10)]
	public string DateTimePeriodFormatQualifier2 { get; set; }

	[Position(11)]
	public string DateTimePeriod2 { get; set; }

	[Position(12)]
	public string DateTimePeriodFormatQualifier3 { get; set; }

	[Position(13)]
	public string DateTimePeriod3 { get; set; }

	[Position(14)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(15)]
	public decimal? Quantity { get; set; }

	[Position(16)]
	public decimal? Quantity2 { get; set; }

	[Position(17)]
	public decimal? Quantity3 { get; set; }

	[Position(18)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(19)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(20)]
	public string DateTimePeriodFormatQualifier4 { get; set; }

	[Position(21)]
	public string DateTimePeriod4 { get; set; }

	[Position(22)]
	public string PaymentMethodTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SLI_SpecificLoanInformation>(this);
		validator.Required(x=>x.LoanTypeCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.MonetaryAmount2);
		validator.Required(x=>x.InterestRate);
		validator.Required(x=>x.LoanRateTypeCode);
		validator.Required(x=>x.DateTimePeriodFormatQualifier);
		validator.Required(x=>x.DateTimePeriod);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier2, x=>x.DateTimePeriod2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier3, x=>x.DateTimePeriod3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier4, x=>x.DateTimePeriod4);
		validator.Length(x => x.LoanTypeCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.InterestRate, 1, 6);
		validator.Length(x => x.LoanRateTypeCode, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier2, 2, 3);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatQualifier3, 2, 3);
		validator.Length(x => x.DateTimePeriod3, 1, 35);
		validator.Length(x => x.MonetaryAmount3, 1, 18);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Quantity2, 1, 15);
		validator.Length(x => x.Quantity3, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.DateTimePeriodFormatQualifier4, 2, 3);
		validator.Length(x => x.DateTimePeriod4, 1, 35);
		validator.Length(x => x.PaymentMethodTypeCode, 1, 2);
		return validator.Results;
	}
}
