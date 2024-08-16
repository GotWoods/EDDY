using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C019")]
public class C019_PaymentTerms : EdifactComponent
{
	[Position(1)]
	public string PaymentTermsDescriptionIdentifier { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string PaymentTermsDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C019_PaymentTerms>(this);
		validator.Length(x => x.PaymentTermsDescriptionIdentifier, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.PaymentTermsDescription, 1, 35);
		return validator.Results;
	}
}
