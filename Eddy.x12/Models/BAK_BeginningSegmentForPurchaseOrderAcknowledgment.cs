using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("BAK")]
public class BAK_BeginningSegmentForPurchaseOrderAcknowledgment : EdiX12Segment 
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string AcknowledgmentTypeCode { get; set; }

	[Position(03)]
	public string PurchaseOrderNumber { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string ReleaseNumber { get; set; }

	[Position(06)]
	public string RequestReferenceNumber { get; set; }

	[Position(07)]
	public string ContractNumber { get; set; }

	[Position(08)]
	public string ReferenceIdentification { get; set; }

	[Position(09)]
	public string Date2 { get; set; }

	[Position(10)]
	public string TransactionTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BAK_BeginningSegmentForPurchaseOrderAcknowledgment>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.AcknowledgmentTypeCode);
		validator.Required(x=>x.PurchaseOrderNumber);
		validator.Required(x=>x.Date);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.AcknowledgmentTypeCode, 2);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.ReleaseNumber, 1, 30);
		validator.Length(x => x.RequestReferenceNumber, 1, 45);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.TransactionTypeCode, 2);
		return validator.Results;
	}
}
