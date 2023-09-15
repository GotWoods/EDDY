using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("BCO")]
public class BCO_BeginningSegmentForContractAward : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string RequestForQuoteReferenceNumber { get; set; }

	[Position(03)]
	public string RequestQuotationControlDate { get; set; }

	[Position(04)]
	public string ReferenceNumber { get; set; }

	[Position(05)]
	public string ContractStatusCode { get; set; }

	[Position(06)]
	public string Date { get; set; }

	[Position(07)]
	public string Date2 { get; set; }

	[Position(08)]
	public string AcknowledgmentType { get; set; }

	[Position(09)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(10)]
	public string ReferenceNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BCO_BeginningSegmentForContractAward>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.RequestForQuoteReferenceNumber);
		validator.Required(x=>x.RequestQuotationControlDate);
		validator.Required(x=>x.ReferenceNumber);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.RequestForQuoteReferenceNumber, 1, 45);
		validator.Length(x => x.RequestQuotationControlDate, 6);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ContractStatusCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.AcknowledgmentType, 2);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber2, 1, 30);
		return validator.Results;
	}
}
