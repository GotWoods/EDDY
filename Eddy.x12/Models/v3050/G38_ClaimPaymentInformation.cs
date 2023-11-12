using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G38")]
public class G38_ClaimPaymentInformation : EdiX12Segment
{
	[Position(01)]
	public decimal? MonetaryAmount { get; set; }

	[Position(02)]
	public string PaymentMethodCode { get; set; }

	[Position(03)]
	public string ReturnsDispositionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G38_ClaimPaymentInformation>(this);
		validator.Required(x=>x.MonetaryAmount);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.PaymentMethodCode, 3);
		validator.Length(x => x.ReturnsDispositionCode, 2);
		return validator.Results;
	}
}
