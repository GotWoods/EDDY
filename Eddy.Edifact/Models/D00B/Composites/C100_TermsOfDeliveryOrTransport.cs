using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C100")]
public class C100_TermsOfDeliveryOrTransport : EdifactComponent
{
	[Position(1)]
	public string DeliveryOrTransportTermsDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string DeliveryOrTransportTermsDescription { get; set; }

	[Position(5)]
	public string DeliveryOrTransportTermsDescription2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C100_TermsOfDeliveryOrTransport>(this);
		validator.Length(x => x.DeliveryOrTransportTermsDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.DeliveryOrTransportTermsDescription, 1, 70);
		validator.Length(x => x.DeliveryOrTransportTermsDescription2, 1, 70);
		return validator.Results;
	}
}
