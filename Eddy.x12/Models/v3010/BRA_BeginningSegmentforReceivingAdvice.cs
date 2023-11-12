using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("BRA")]
public class BRA_BeginningSegmentForReceivingAdvice : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumber { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(04)]
	public string ReceivingAdviceTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BRA_BeginningSegmentForReceivingAdvice>(this);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ReceivingAdviceTypeCode);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReceivingAdviceTypeCode, 1);
		return validator.Results;
	}
}
