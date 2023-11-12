using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("BOS")]
public class BOS_BeginningSegmentForTheOperatingExpenseStatement : EdiX12Segment
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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BOS_BeginningSegmentForTheOperatingExpenseStatement>(this);
		validator.Required(x=>x.StatementNumber);
		validator.Required(x=>x.Date);
		validator.Length(x => x.StatementNumber, 1, 16);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.AgencyQualifierCode, 2);
		validator.Length(x => x.StatementFormatCode, 6);
		validator.Length(x => x.TransactionTypeCode, 2);
		return validator.Results;
	}
}
