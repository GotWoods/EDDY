using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C524")]
public class C524_HandlingInstructions : EdifactComponent
{
	[Position(1)]
	public string HandlingInstructionsCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string HandlingInstructions { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C524_HandlingInstructions>(this);
		validator.Length(x => x.HandlingInstructionsCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.HandlingInstructions, 1, 70);
		return validator.Results;
	}
}
