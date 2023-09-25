using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("BSC")]
public class BSC_BeginningSegmentForCommissionSalesReport : EdiX12Segment
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
		var validator = new BasicValidator<BSC_BeginningSegmentForCommissionSalesReport>(this);
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
