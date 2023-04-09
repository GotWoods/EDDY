using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("BSC")]
public class BSC_BeginningSegmentForCommissionSalesReportAndPeriodicCompensation : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string Date2 { get; set; }

	[Position(04)]
	public string Date3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BSC_BeginningSegmentForCommissionSalesReportAndPeriodicCompensation>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Date2);
		validator.Required(x=>x.Date3);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Date3, 8);
		return validator.Results;
	}
}
