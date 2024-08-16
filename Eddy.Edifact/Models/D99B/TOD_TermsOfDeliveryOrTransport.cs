using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("TOD")]
public class TOD_TermsOfDeliveryOrTransport : EdifactSegment
{
	[Position(1)]
	public string TermsOfDeliveryOrTransportFunctionCoded { get; set; }

	[Position(2)]
	public string TransportChargesPaymentMethodCode { get; set; }

	[Position(3)]
	public C100_TermsOfDeliveryOrTransport TermsOfDeliveryOrTransport { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TOD_TermsOfDeliveryOrTransport>(this);
		validator.Length(x => x.TermsOfDeliveryOrTransportFunctionCoded, 1, 3);
		validator.Length(x => x.TransportChargesPaymentMethodCode, 1, 3);
		return validator.Results;
	}
}
