using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E022")]
public class E022_InstructionInformation : EdifactComponent
{
	[Position(1)]
	public string InstructionDescriptionCode { get; set; }

	[Position(2)]
	public string InstructionTypeCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E022_InstructionInformation>(this);
		validator.Required(x=>x.InstructionDescriptionCode);
		validator.Length(x => x.InstructionDescriptionCode, 1, 3);
		validator.Length(x => x.InstructionTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
