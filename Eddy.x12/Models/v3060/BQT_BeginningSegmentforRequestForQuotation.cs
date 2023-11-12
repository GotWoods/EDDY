using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("BQT")]
public class BQT_BeginningSegmentForRequestForQuotation : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string RequestForQuoteReferenceNumber { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string DateTimeQualifier { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	[Position(06)]
	public string PurchaseOrderTypeCode { get; set; }

	[Position(07)]
	public string RequestForQuoteTypeCode { get; set; }

	[Position(08)]
	public string ContractTypeCode { get; set; }

	[Position(09)]
	public string SecurityLevelCode { get; set; }

	[Position(10)]
	public string PurchaseCategory { get; set; }

	[Position(11)]
	public string ChangeOrderSequenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BQT_BeginningSegmentForRequestForQuotation>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.RequestForQuoteReferenceNumber);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimeQualifier, x=>x.Date2);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.RequestForQuoteReferenceNumber, 1, 45);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.PurchaseOrderTypeCode, 2);
		validator.Length(x => x.RequestForQuoteTypeCode, 2);
		validator.Length(x => x.ContractTypeCode, 2);
		validator.Length(x => x.SecurityLevelCode, 2);
		validator.Length(x => x.PurchaseCategory, 2);
		validator.Length(x => x.ChangeOrderSequenceNumber, 1, 8);
		return validator.Results;
	}
}
