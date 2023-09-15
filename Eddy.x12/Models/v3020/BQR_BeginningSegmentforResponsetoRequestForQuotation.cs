using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("BQR")]
public class BQR_BeginningSegmentForResponseToRequestForQuotation : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string RequestForQuoteReferenceNumber { get; set; }

	[Position(03)]
	public string RequestQuotationControlDate { get; set; }

	[Position(04)]
	public string DateTimeQualifier { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string BidTypeResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BQR_BeginningSegmentForResponseToRequestForQuotation>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.RequestForQuoteReferenceNumber);
		validator.Required(x=>x.RequestQuotationControlDate);
		validator.ARequiresB(x=>x.Date, x=>x.DateTimeQualifier);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.RequestForQuoteReferenceNumber, 1, 45);
		validator.Length(x => x.RequestQuotationControlDate, 6);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.BidTypeResponseCode, 2);
		return validator.Results;
	}
}
