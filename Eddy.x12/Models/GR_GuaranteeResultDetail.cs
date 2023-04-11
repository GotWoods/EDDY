using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("GR")]
public class GR_GuaranteeResultDetail : EdiX12Segment
{
	[Position(01)]
	public string LoanTypeCode { get; set; }

	[Position(02)]
	public string LoanStatusCode { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string DateTimePeriodFormatQualifier2 { get; set; }

	[Position(06)]
	public string DateTimePeriod2 { get; set; }

	[Position(07)]
	public string DateTimePeriodFormatQualifier3 { get; set; }

	[Position(08)]
	public string DateTimePeriod3 { get; set; }

	[Position(09)]
	public decimal? MonetaryAmount { get; set; }

	[Position(10)]
	public decimal? InterestRate { get; set; }

	[Position(11)]
	public string LoanRateTypeCode { get; set; }

	[Position(12)]
	public decimal? InterestRate2 { get; set; }

	[Position(13)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(14)]
	public string ReferenceIdentification { get; set; }

	[Position(15)]
	public string DateTimePeriodFormatQualifier4 { get; set; }

	[Position(16)]
	public string DateTimePeriod4 { get; set; }

	[Position(17)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(18)]
	public string ReferenceIdentification2 { get; set; }

	[Position(19)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(20)]
	public decimal? Quantity { get; set; }

	[Position(21)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(22)]
	public string GuaranteeAmountReductionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GR_GuaranteeResultDetail>(this);
		validator.Required(x=>x.LoanTypeCode);
		validator.Required(x=>x.LoanStatusCode);
		validator.Required(x=>x.DateTimePeriodFormatQualifier);
		validator.Required(x=>x.DateTimePeriod);
		validator.Required(x=>x.DateTimePeriodFormatQualifier2);
		validator.Required(x=>x.DateTimePeriod2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier3, x=>x.DateTimePeriod3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.InterestRate, x=>x.LoanRateTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimePeriodFormatQualifier4, x=>x.DateTimePeriod4);
		validator.Length(x => x.LoanTypeCode, 1, 2);
		validator.Length(x => x.LoanStatusCode, 1, 2);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatQualifier2, 2, 3);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.DateTimePeriodFormatQualifier3, 2, 3);
		validator.Length(x => x.DateTimePeriod3, 1, 35);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.InterestRate, 1, 6);
		validator.Length(x => x.LoanRateTypeCode, 1);
		validator.Length(x => x.InterestRate2, 1, 6);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.DateTimePeriodFormatQualifier4, 2, 3);
		validator.Length(x => x.DateTimePeriod4, 1, 35);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.GuaranteeAmountReductionCode, 1, 2);
		return validator.Results;
	}
}
