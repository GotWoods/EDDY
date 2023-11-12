using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

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
	public int? Century { get; set; }

	[Position(07)]
	public int? YearWithinCentury { get; set; }

	[Position(08)]
	public string MonthOfTheYearCode { get; set; }

	[Position(09)]
	public int? Century2 { get; set; }

	[Position(10)]
	public int? YearWithinCentury2 { get; set; }

	[Position(11)]
	public string MonthOfTheYearCode2 { get; set; }

	[Position(12)]
	public string AccountDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CTC_CarHireTransactionControl>(this);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.StandardCarrierAlphaCode2);
		validator.Required(x=>x.CarHireDetailSummaryCode);
		validator.Required(x=>x.AccountTypeCode);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.Century);
		validator.Required(x=>x.YearWithinCentury);
		validator.Required(x=>x.MonthOfTheYearCode);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.StandardCarrierAlphaCode2, 2, 4);
		validator.Length(x => x.CarHireDetailSummaryCode, 1);
		validator.Length(x => x.AccountTypeCode, 2);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.Century, 2);
		validator.Length(x => x.YearWithinCentury, 2);
		validator.Length(x => x.MonthOfTheYearCode, 2);
		validator.Length(x => x.Century2, 2);
		validator.Length(x => x.YearWithinCentury2, 2);
		validator.Length(x => x.MonthOfTheYearCode2, 2);
		validator.Length(x => x.AccountDescriptionCode, 1, 2);
		return validator.Results;
	}
}
