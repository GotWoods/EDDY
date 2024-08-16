using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C849")]
public class C849_PartiesToInstruction : EdifactComponent
{
	[Position(1)]
	public string PartyEnactingInstructionIdentification { get; set; }

	[Position(2)]
	public string RecipientOfTheInstructionIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C849_PartiesToInstruction>(this);
		validator.Required(x=>x.PartyEnactingInstructionIdentification);
		validator.Length(x => x.PartyEnactingInstructionIdentification, 1, 17);
		validator.Length(x => x.RecipientOfTheInstructionIdentification, 1, 17);
		return validator.Results;
	}
}
