using EdiParser.Attributes;
using EdiParser.Validation;
using EdiParser.x12.Internals;

namespace EdiParser.x12.Models;

[Segment("CPI")]
public class CPI_ClaimantPaymentInformation : EdiX12Segment
{
	[Position(01)]
	public string PaymentHandlingCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CPI_ClaimantPaymentInformation>(this);
		validator.Required(x=>x.PaymentHandlingCode);
		validator.Length(x => x.PaymentHandlingCode, 2);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}

class CpiClaimantPaymentInformation : CPI_ClaimantPaymentInformation
{
}
