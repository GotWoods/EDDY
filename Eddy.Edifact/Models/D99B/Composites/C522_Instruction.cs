using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C522")]
public class C522_Instruction : EdifactComponent
{
	[Position(1)]
	public string InstructionTypeCodeQualifier { get; set; }

	[Position(2)]
	public string InstructionDescriptionCode { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(5)]
	public string InstructionDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C522_Instruction>(this);
		validator.Required(x=>x.InstructionTypeCodeQualifier);
		validator.Length(x => x.InstructionTypeCodeQualifier, 1, 3);
		validator.Length(x => x.InstructionDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.InstructionDescription, 1, 35);
		return validator.Results;
	}
}
