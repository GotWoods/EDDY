using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C100")]
public class C100_TermsOfDeliveryOrTransport : EdifactComponent
{
	[Position(1)]
	public string TermsOfDeliveryOrTransportCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string TermsOfDeliveryOrTransport { get; set; }

	[Position(5)]
	public string TermsOfDeliveryOrTransport2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C100_TermsOfDeliveryOrTransport>(this);
		validator.Length(x => x.TermsOfDeliveryOrTransportCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.TermsOfDeliveryOrTransport, 1, 70);
		validator.Length(x => x.TermsOfDeliveryOrTransport2, 1, 70);
		return validator.Results;
	}
}
