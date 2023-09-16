using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("OTI")]
public class OTI_OriginalTransactionIdentification : EdiX12Segment
{
	[Position(01)]
	public string ApplicationAcknowledgmentCode { get; set; }

	[Position(02)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(03)]
	public string ReferenceIdentification { get; set; }

	[Position(04)]
	public string ApplicationSendersCode { get; set; }

	[Position(05)]
	public string ApplicationReceiversCode { get; set; }

	[Position(06)]
	public string Date { get; set; }

	[Position(07)]
	public string Time { get; set; }

	[Position(08)]
	public int? GroupControlNumber { get; set; }

	[Position(09)]
	public string TransactionSetControlNumber { get; set; }

	[Position(10)]
	public string TransactionSetIdentifierCode { get; set; }

	[Position(11)]
	public string VersionReleaseIndustryIdentifierCode { get; set; }

	[Position(12)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(13)]
	public string TransactionTypeCode { get; set; }

	[Position(14)]
	public string ApplicationTypeCode { get; set; }

	[Position(15)]
	public string ActionCode { get; set; }

	[Position(16)]
	public string TransactionHandlingCode { get; set; }

	[Position(17)]
	public string StatusReasonCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OTI_OriginalTransactionIdentification>(this);
		validator.Required(x=>x.ApplicationAcknowledgmentCode);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.ARequiresB(x=>x.TransactionSetControlNumber, x=>x.GroupControlNumber);
		validator.Length(x => x.ApplicationAcknowledgmentCode, 1, 2);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ApplicationSendersCode, 2, 15);
		validator.Length(x => x.ApplicationReceiversCode, 2, 15);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.GroupControlNumber, 1, 9);
		validator.Length(x => x.TransactionSetControlNumber, 4, 9);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.VersionReleaseIndustryIdentifierCode, 1, 12);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.ApplicationTypeCode, 2);
		validator.Length(x => x.ActionCode, 1, 2);
		validator.Length(x => x.TransactionHandlingCode, 1, 2);
		validator.Length(x => x.StatusReasonCode, 3);
		return validator.Results;
	}
}
