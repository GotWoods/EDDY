using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C524")]
public class C524_HandlingInstructions : EdifactComponent
{
	[Position(1)]
	public string HandlingInstructionDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string HandlingInstructionDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C524_HandlingInstructions>(this);
		validator.Length(x => x.HandlingInstructionDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.HandlingInstructionDescription, 1, 70);
		return validator.Results;
	}
}
