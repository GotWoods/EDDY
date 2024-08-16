using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C534")]
public class C534_PaymentInstructionDetails : EdifactComponent
{
	[Position(1)]
	public string PaymentConditionsCoded { get; set; }

	[Position(2)]
	public string PaymentGuaranteeCoded { get; set; }

	[Position(3)]
	public string PaymentMeansCoded { get; set; }

	[Position(4)]
	public string CodeListQualifier { get; set; }

	[Position(5)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(6)]
	public string PaymentChannelCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C534_PaymentInstructionDetails>(this);
		validator.Length(x => x.PaymentConditionsCoded, 1, 3);
		validator.Length(x => x.PaymentGuaranteeCoded, 1, 3);
		validator.Length(x => x.PaymentMeansCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.PaymentChannelCoded, 1, 3);
		return validator.Results;
	}
}
