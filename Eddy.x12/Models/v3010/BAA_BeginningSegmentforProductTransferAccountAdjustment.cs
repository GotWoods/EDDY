using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("BAA")]
public class BAA_BeginningSegmentForProductTransferAccountAdjustment : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string TransactionTypeCode { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(05)]
	public string ReferenceNumber { get; set; }

	[Position(06)]
	public string Time { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BAA_BeginningSegmentForProductTransferAccountAdjustment>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.TransactionTypeCode);
		validator.Required(x=>x.Date);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Time, 4);
		return validator.Results;
	}
}
