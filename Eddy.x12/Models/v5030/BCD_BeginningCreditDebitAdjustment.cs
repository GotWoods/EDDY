using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("BCD")]
public class BCD_BeginningCreditDebitAdjustment : EdiX12Segment
{
	[Position(01)]
	public string Date { get; set; }

	[Position(02)]
	public string CreditDebitAdjustmentNumber { get; set; }

	[Position(03)]
	public string TransactionHandlingCode { get; set; }

	[Position(04)]
	public string Amount { get; set; }

	[Position(05)]
	public string CreditDebitFlagCode { get; set; }

	[Position(06)]
	public string Date2 { get; set; }

	[Position(07)]
	public string InvoiceNumber { get; set; }

	[Position(08)]
	public string VendorOrderNumber { get; set; }

	[Position(09)]
	public string Date3 { get; set; }

	[Position(10)]
	public string PurchaseOrderNumber { get; set; }

	[Position(11)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(12)]
	public string TransactionTypeCode { get; set; }

	[Position(13)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(14)]
	public string ReferenceIdentification { get; set; }

	[Position(15)]
	public string ActionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BCD_BeginningCreditDebitAdjustment>(this);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.CreditDebitAdjustmentNumber);
		validator.Required(x=>x.TransactionHandlingCode);
		validator.Required(x=>x.Amount);
		validator.Required(x=>x.CreditDebitFlagCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceIdentificationQualifier, x=>x.ReferenceIdentification);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.CreditDebitAdjustmentNumber, 1, 22);
		validator.Length(x => x.TransactionHandlingCode, 1, 2);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.CreditDebitFlagCode, 1);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.VendorOrderNumber, 1, 22);
		validator.Length(x => x.Date3, 8);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ActionCode, 1, 2);
		return validator.Results;
	}
}
