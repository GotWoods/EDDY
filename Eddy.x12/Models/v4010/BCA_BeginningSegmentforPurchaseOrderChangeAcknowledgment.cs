using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("BCA")]
public class BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string AcknowledgmentType { get; set; }

	[Position(03)]
	public string PurchaseOrderNumber { get; set; }

	[Position(04)]
	public string ReleaseNumber { get; set; }

	[Position(05)]
	public string ChangeOrderSequenceNumber { get; set; }

	[Position(06)]
	public string Date { get; set; }

	[Position(07)]
	public string RequestReferenceNumber { get; set; }

	[Position(08)]
	public string ContractNumber { get; set; }

	[Position(09)]
	public string ReferenceIdentification { get; set; }

	[Position(10)]
	public string Date2 { get; set; }

	[Position(11)]
	public string Date3 { get; set; }

	[Position(12)]
	public string Date4 { get; set; }

	[Position(13)]
	public string PurchaseOrderTypeCode { get; set; }

	[Position(14)]
	public string SecurityLevelCode { get; set; }

	[Position(15)]
	public string TransactionTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BCA_BeginningSegmentForPurchaseOrderChangeAcknowledgment>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.PurchaseOrderNumber);
		validator.Required(x=>x.Date);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.AcknowledgmentType, 2);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.ReleaseNumber, 1, 30);
		validator.Length(x => x.ChangeOrderSequenceNumber, 1, 8);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.RequestReferenceNumber, 1, 45);
		validator.Length(x => x.ContractNumber, 1, 30);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Date3, 8);
		validator.Length(x => x.Date4, 8);
		validator.Length(x => x.PurchaseOrderTypeCode, 2);
		validator.Length(x => x.SecurityLevelCode, 2);
		validator.Length(x => x.TransactionTypeCode, 2);
		return validator.Results;
	}
}
