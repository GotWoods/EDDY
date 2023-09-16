using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("OTI")]
public class OTI_OriginalTransactionIdentification : EdiX12Segment
{
	[Position(01)]
	public string ApplicationAcknowledgmentCode { get; set; }

	[Position(02)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(03)]
	public string ReferenceNumber { get; set; }

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

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<OTI_OriginalTransactionIdentification>(this);
		validator.Required(x=>x.ApplicationAcknowledgmentCode);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.ARequiresB(x=>x.TransactionSetControlNumber, x=>x.GroupControlNumber);
		validator.Length(x => x.ApplicationAcknowledgmentCode, 1, 2);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.ApplicationSendersCode, 2, 15);
		validator.Length(x => x.ApplicationReceiversCode, 2, 15);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 6);
		validator.Length(x => x.GroupControlNumber, 1, 9);
		validator.Length(x => x.TransactionSetControlNumber, 4, 9);
		validator.Length(x => x.TransactionSetIdentifierCode, 3);
		validator.Length(x => x.VersionReleaseIndustryIdentifierCode, 1, 12);
		return validator.Results;
	}
}
