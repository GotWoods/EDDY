using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4020;

[Segment("BIG")]
public class BIG_BeginningSegmentForInvoice : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string InvoiceNumber { get; set; }

	[Position(03)]
	public string Date2 { get; set; }

	[Position(04)]
	public string PurchaseOrderNumber { get; set; }

	[Position(05)]
	public string ReleaseNumber { get; set; }

	[Position(06)]
	public string ChangeOrderSequenceNumber { get; set; }

	[Position(07)]
	public string TransactionTypeCode { get; set; }

	[Position(08)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(09)]
	public string ActionCode { get; set; }

	[Position(10)]
	public string InvoiceNumber2 { get; set; }

	[Position(11)]
	public string HierarchicalStructureCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BIG_BeginningSegmentForInvoice>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.InvoiceNumber);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.ReleaseNumber, 1, 30);
		validator.Length(x => x.ChangeOrderSequenceNumber, 1, 8);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.InvoiceNumber2, 1, 22);
		validator.Length(x => x.HierarchicalStructureCode, 4);
		return validator.Results;
	}
}
