using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CTC")]
public class CTC_CarHireTransactionControl : EdiX12Segment
{
	[Position(01)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode2 { get; set; }

	[Position(03)]
	public string CarHireDetailSummaryCode { get; set; }

	[Position(04)]
	public string AccountTypeCode { get; set; }

	[Position(05)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(06)]
	public int? Year { get; set; }

	[Position(07)]
	public string MonthOfTheYearCode { get; set; }

	[Position(08)]
	public int? Year2 { get; set; }

	[Position(09)]
	public string MonthOfTheYearCode2 { get; set; }

	[Position(10)]
	public string AccountDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CTC_CarHireTransactionControl>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.StandardCarrierAlphaCode2);
		validator.Required(x=>x.CarHireDetailSummaryCode);
		validator.Required(x=>x.AccountTypeCode);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.Year);
		validator.Required(x=>x.MonthOfTheYearCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Year2, x=>x.MonthOfTheYearCode2);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.CarHireDetailSummaryCode, 1);
		validator.Length(x => x.AccountTypeCode, 2);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.Year, 4);
		validator.Length(x => x.MonthOfTheYearCode, 2);
		validator.Length(x => x.Year2, 4);
		validator.Length(x => x.MonthOfTheYearCode2, 2);
		validator.Length(x => x.AccountDescriptionCode, 1, 2);
		return validator.Results;
	}
}
