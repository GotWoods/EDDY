using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C534")]
public class C534_PaymentInstructionDetails : EdifactComponent
{
	[Position(1)]
	public string PaymentConditionsCode { get; set; }

	[Position(2)]
	public string PaymentGuaranteeMeansCode { get; set; }

	[Position(3)]
	public string PaymentMeansCode { get; set; }

	[Position(4)]
	public string CodeListIdentificationCode { get; set; }

	[Position(5)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(6)]
	public string PaymentChannelCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C534_PaymentInstructionDetails>(this);
		validator.Length(x => x.PaymentConditionsCode, 1, 3);
		validator.Length(x => x.PaymentGuaranteeMeansCode, 1, 3);
		validator.Length(x => x.PaymentMeansCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.PaymentChannelCode, 1, 3);
		return validator.Results;
	}
}
