using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C231")]
public class C231_MethodOfPayment : EdifactComponent
{
	[Position(1)]
	public string TransportChargesPaymentMethodCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C231_MethodOfPayment>(this);
		validator.Required(x=>x.TransportChargesPaymentMethodCode);
		validator.Length(x => x.TransportChargesPaymentMethodCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
