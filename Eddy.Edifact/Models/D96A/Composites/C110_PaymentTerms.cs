using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C110")]
public class C110_PaymentTerms : EdifactComponent
{
	[Position(1)]
	public string TermsOfPaymentIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string TermsOfPayment { get; set; }

	[Position(5)]
	public string TermsOfPayment2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C110_PaymentTerms>(this);
		validator.Required(x=>x.TermsOfPaymentIdentification);
		validator.Length(x => x.TermsOfPaymentIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.TermsOfPayment, 1, 35);
		validator.Length(x => x.TermsOfPayment2, 1, 35);
		return validator.Results;
	}
}
