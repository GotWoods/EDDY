using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S305")]
public class S305_DialogueIdentification : EdifactComponent
{
	[Position(1)]
	public string DialogueIdentification { get; set; }

	[Position(2)]
	public string DialogueVersionNumber { get; set; }

	[Position(3)]
	public string DialogueReleaseNumber { get; set; }

	[Position(4)]
	public string ControllingAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S305_DialogueIdentification>(this);
		validator.Required(x=>x.DialogueIdentification);
		validator.Length(x => x.DialogueIdentification, 1, 14);
		validator.Length(x => x.DialogueVersionNumber, 1, 3);
		validator.Length(x => x.DialogueReleaseNumber, 1, 3);
		validator.Length(x => x.ControllingAgencyCoded, 1, 3);
		return validator.Results;
	}
}
