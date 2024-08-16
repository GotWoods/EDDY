using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C522")]
public class C522_Instruction : EdifactComponent
{
	[Position(1)]
	public string InstructionQualifier { get; set; }

	[Position(2)]
	public string InstructionCoded { get; set; }

	[Position(3)]
	public string CodeListQualifier { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(5)]
	public string Instruction { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C522_Instruction>(this);
		validator.Required(x=>x.InstructionQualifier);
		validator.Length(x => x.InstructionQualifier, 1, 3);
		validator.Length(x => x.InstructionCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.Instruction, 1, 35);
		return validator.Results;
	}
}
