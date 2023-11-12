using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("BRA")]
public class BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumber { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(04)]
	public string ReceivingAdviceOrAcceptanceCertificateTypeCode { get; set; }

	[Position(05)]
	public string Time { get; set; }

	[Position(06)]
	public string ReceivingConditionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BRA_BeginningSegmentForReceivingAdviceOrAcceptanceCertificate>(this);
		validator.Required(x=>x.ReferenceNumber);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ReceivingAdviceOrAcceptanceCertificateTypeCode);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReceivingAdviceOrAcceptanceCertificateTypeCode, 1);
		validator.Length(x => x.Time, 4, 6);
		validator.Length(x => x.ReceivingConditionCode, 2);
		return validator.Results;
	}
}
