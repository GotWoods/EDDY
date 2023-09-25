using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("TXP")]
public class TXP_TaxPayment : EdiX12Segment
{
	[Position(01)]
	public string TaxIdentificationNumber { get; set; }

	[Position(02)]
	public string TaxPaymentTypeCode { get; set; }

	[Position(03)]
	public string Date { get; set; }

	[Position(04)]
	public string TaxInformationIdentificationNumber { get; set; }

	[Position(05)]
	public string TaxAmount { get; set; }

	[Position(06)]
	public string TaxInformationIdentificationNumber2 { get; set; }

	[Position(07)]
	public string TaxAmount2 { get; set; }

	[Position(08)]
	public string TaxInformationIdentificationNumber3 { get; set; }

	[Position(09)]
	public string TaxAmount3 { get; set; }

	[Position(10)]
	public string TaxpayerVerification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TXP_TaxPayment>(this);
		validator.Required(x=>x.TaxIdentificationNumber);
		validator.Required(x=>x.TaxPaymentTypeCode);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.TaxInformationIdentificationNumber);
		validator.Required(x=>x.TaxAmount);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TaxInformationIdentificationNumber2, x=>x.TaxAmount2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TaxInformationIdentificationNumber3, x=>x.TaxAmount3);
		validator.Length(x => x.TaxIdentificationNumber, 1, 20);
		validator.Length(x => x.TaxPaymentTypeCode, 1, 5);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.TaxInformationIdentificationNumber, 1, 30);
		validator.Length(x => x.TaxAmount, 1, 10);
		validator.Length(x => x.TaxInformationIdentificationNumber2, 1, 30);
		validator.Length(x => x.TaxAmount2, 1, 10);
		validator.Length(x => x.TaxInformationIdentificationNumber3, 1, 30);
		validator.Length(x => x.TaxAmount3, 1, 10);
		validator.Length(x => x.TaxpayerVerification, 1, 6);
		return validator.Results;
	}
}
