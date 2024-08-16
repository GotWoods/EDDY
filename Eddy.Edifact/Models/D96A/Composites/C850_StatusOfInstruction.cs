using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C850")]
public class C850_StatusOfInstruction : EdifactComponent
{
	[Position(1)]
	public string StatusCoded { get; set; }

	[Position(2)]
	public string PartyName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C850_StatusOfInstruction>(this);
		validator.Required(x=>x.StatusCoded);
		validator.Length(x => x.StatusCoded, 1, 3);
		validator.Length(x => x.PartyName, 1, 35);
		return validator.Results;
	}
}
