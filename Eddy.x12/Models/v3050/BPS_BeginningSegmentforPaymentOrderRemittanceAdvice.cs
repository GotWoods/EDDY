using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("BPS")]
public class BPS_BeginningSegmentForPaymentOrderRemittanceAdvice : EdiX12Segment
{
	[Position(01)]
	public string PaymentMethodCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string TransactionHandlingCode { get; set; }

	[Position(04)]
	public string DFIIDNumberQualifier { get; set; }

	[Position(05)]
	public string DFIIdentificationNumber { get; set; }

	[Position(06)]
	public string AccountNumber { get; set; }

	[Position(07)]
	public string OriginatingCompanyIdentifier { get; set; }

	[Position(08)]
	public string OriginatingCompanySupplementalCode { get; set; }

	[Position(09)]
	public string DFIIDNumberQualifier2 { get; set; }

	[Position(10)]
	public string DFIIdentificationNumber2 { get; set; }

	[Position(11)]
	public string AccountNumber2 { get; set; }

	[Position(12)]
	public string Date { get; set; }

	[Position(13)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BPS_BeginningSegmentForPaymentOrderRemittanceAdvice>(this);
		validator.Required(x=>x.PaymentMethodCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.TransactionHandlingCode);
		validator.Length(x => x.PaymentMethodCode, 3);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.TransactionHandlingCode, 1, 2);
		validator.Length(x => x.DFIIDNumberQualifier, 2);
		validator.Length(x => x.DFIIdentificationNumber, 3, 12);
		validator.Length(x => x.AccountNumber, 1, 35);
		validator.Length(x => x.OriginatingCompanyIdentifier, 10);
		validator.Length(x => x.OriginatingCompanySupplementalCode, 9);
		validator.Length(x => x.DFIIDNumberQualifier2, 2);
		validator.Length(x => x.DFIIdentificationNumber2, 3, 12);
		validator.Length(x => x.AccountNumber2, 1, 35);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		return validator.Results;
	}
}
