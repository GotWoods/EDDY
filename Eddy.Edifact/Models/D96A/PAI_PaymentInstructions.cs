using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("PAI")]
public class PAI_PaymentInstructions : EdifactSegment
{
	[Position(1)]
	public C534_PaymentInstructionDetails PaymentInstructionDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PAI_PaymentInstructions>(this);
		validator.Required(x=>x.PaymentInstructionDetails);
		return validator.Results;
	}
}
