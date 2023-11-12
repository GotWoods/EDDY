using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("BTP")]
public class BTP_BeginningSegmentForTradingPartnerProfile : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string Time { get; set; }

	[Position(05)]
	public string TransactionTypeCode { get; set; }

	[Position(06)]
	public string TransactionSetPurposeCode2 { get; set; }

	[Position(07)]
	public string ReferenceIdentification2 { get; set; }

	[Position(08)]
	public string Date2 { get; set; }

	[Position(09)]
	public string Time2 { get; set; }

	[Position(10)]
	public string PaymentMethodCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BTP_BeginningSegmentForTradingPartnerProfile>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.Time);
		validator.Required(x=>x.TransactionTypeCode);
		validator.ARequiresB(x=>x.Date2, x=>x.ReferenceIdentification2);
		validator.ARequiresB(x=>x.Time2, x=>x.Date2);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.ReferenceIdentification, 1, 50);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TransactionTypeCode, 2);
		validator.Length(x => x.TransactionSetPurposeCode2, 2);
		validator.Length(x => x.ReferenceIdentification2, 1, 50);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Time2, 4, 8);
		validator.Length(x => x.PaymentMethodCode, 3);
		return validator.Results;
	}
}
