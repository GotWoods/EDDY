using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("PMT")]
public class PMT_PaymentInformation : EdifactSegment
{
	[Position(1)]
	public E977_PaymentDetails PaymentDetails { get; set; }

	[Position(2)]
	public E978_CreditCardInformation CreditCardInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PMT_PaymentInformation>(this);
		return validator.Results;
	}
}
