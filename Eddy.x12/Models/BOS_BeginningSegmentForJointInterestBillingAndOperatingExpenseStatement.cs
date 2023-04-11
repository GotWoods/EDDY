using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("BOS")]
public class BOS_BeginningSegmentForJointInterestBillingAndOperatingExpenseStatement : EdiX12Segment
{
	[Position(01)]
	public string StatementNumber { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string AgencyQualifierCode { get; set; }

	[Position(04)]
	public string StatementFormatCode { get; set; }

	[Position(05)]
	public string TransactionTypeCode { get; set; }

	[Position(06)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BOS_BeginningSegmentForJointInterestBillingAndOperatingExpenseStatement>(this);
		validator.Required(x=>x.StatementNumber);
		validator.Required(x=>x.Date);
		validator.Length(x => x.StatementNumber, 1, 16);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.StatementFormatCode, 6);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.Date2, 8);
		return validator.Results;
	}
}
