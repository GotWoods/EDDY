using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C524")]
public class C524_HandlingInstructions : EdifactComponent
{
	[Position(1)]
	public string HandlingInstructionsCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string HandlingInstructions { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C524_HandlingInstructions>(this);
		validator.Length(x => x.HandlingInstructionsCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.HandlingInstructions, 1, 70);
		return validator.Results;
	}
}
