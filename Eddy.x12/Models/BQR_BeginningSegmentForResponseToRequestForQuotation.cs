using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("BQR")]
public class BQR_BeginningSegmentForResponseToRequestForQuotation : EdiX12Segment
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
	public string BidTypeResponseCode { get; set; }

	[Position(07)]
	public string SecurityLevelCode { get; set; }

	[Position(08)]
	public string ChangeOrderSequenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BQR_BeginningSegmentForResponseToRequestForQuotation>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.RequestForQuoteReferenceNumber);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.DateTimeQualifier, x=>x.Date2);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.RequestForQuoteReferenceNumber, 1, 45);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.BidTypeResponseCode, 2);
		validator.Length(x => x.SecurityLevelCode, 2);
		validator.Length(x => x.ChangeOrderSequenceNumber, 1, 8);
		return validator.Results;
	}
}
