using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("LN1")]
public class LN1_LoanSpecificData : EdiX12Segment
{
	[Position(01)]
	public decimal? MonetaryAmount { get; set; }

	[Position(02)]
	public string LienPriorityCode { get; set; }

	[Position(03)]
	public string RealEstateLoanTypeCode { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(05)]
	public decimal? Percent { get; set; }

	[Position(06)]
	public decimal? Percent2 { get; set; }

	[Position(07)]
	public string RateValueQualifier { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(09)]
	public string RealEstateLoanSecurityInstrumentCode { get; set; }

	[Position(10)]
	public string LoanDocumentationTypeCode { get; set; }

	[Position(11)]
	public string LoanRateTypeCode { get; set; }

	[Position(12)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(13)]
	public string AccountNumber { get; set; }

	[Position(14)]
	public decimal? Percent3 { get; set; }

	[Position(15)]
	public decimal? Percent4 { get; set; }

	[Position(16)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(17)]
	public string DateTimePeriod { get; set; }

	[Position(18)]
	public string DateTimePeriod2 { get; set; }

	[Position(19)]
	public string DateTimePeriod3 { get; set; }

	[Position(20)]
	public string DateTimePeriod4 { get; set; }

	[Position(21)]
	public string DateTimePeriod5 { get; set; }

	[Position(22)]
	public decimal? MonetaryAmount4 { get; set; }

	[Position(23)]
	public decimal? MonetaryAmount5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LN1_LoanSpecificData>(this);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.LienPriorityCode);
		validator.Required(x=>x.RealEstateLoanTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.RateValueQualifier, x=>x.MonetaryAmount3);
		validator.IfOneIsFilledThenAtLeastOne(x=>x.DateTimePeriodFormatQualifier, x=>x.DateTimePeriod, x=>x.DateTimePeriod2, x=>x.DateTimePeriod3, x=>x.DateTimePeriod4, x=>x.DateTimePeriod5);
		validator.ARequiresB(x=>x.DateTimePeriod, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod2, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod3, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod4, x=>x.DateTimePeriodFormatQualifier);
		validator.ARequiresB(x=>x.DateTimePeriod5, x=>x.DateTimePeriodFormatQualifier);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.LienPriorityCode, 1);
		validator.Length(x => x.RealEstateLoanTypeCode, 1);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.Percent, 1, 10);
		validator.Length(x => x.Percent2, 1, 10);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.MonetaryAmount3, 1, 18);
		validator.Length(x => x.RealEstateLoanSecurityInstrumentCode, 1);
		validator.Length(x => x.LoanDocumentationTypeCode, 1);
		validator.Length(x => x.LoanRateTypeCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.Percent3, 1, 10);
		validator.Length(x => x.Percent4, 1, 10);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.DateTimePeriod2, 1, 35);
		validator.Length(x => x.DateTimePeriod3, 1, 35);
		validator.Length(x => x.DateTimePeriod4, 1, 35);
		validator.Length(x => x.DateTimePeriod5, 1, 35);
		validator.Length(x => x.MonetaryAmount4, 1, 18);
		validator.Length(x => x.MonetaryAmount5, 1, 18);
		return validator.Results;
	}
}
