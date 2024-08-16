using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D08B.Composites;

[Segment("C850")]
public class C850_StatusOfInstruction : EdifactComponent
{
	[Position(1)]
	public string StatusDescriptionCode { get; set; }

	[Position(2)]
	public string PartyName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C850_StatusOfInstruction>(this);
		validator.Required(x=>x.StatusDescriptionCode);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		validator.Length(x => x.PartyName, 1, 70);
		return validator.Results;
	}
}
