using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("PCR")]
public class PCR_PaymentCancellationRequest : EdiX12Segment
{
	[Position(01)]
	public string PaymentCancellationTypeCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PCR_PaymentCancellationRequest>(this);
		validator.Required(x=>x.PaymentCancellationTypeCode);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.PaymentCancellationTypeCode, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		return validator.Results;
	}
}
