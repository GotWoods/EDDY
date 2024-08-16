using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S302")]
public class S302_DialogueReference : EdifactComponent
{
	[Position(1)]
	public string InitiatorControlReference { get; set; }

	[Position(2)]
	public string InitiatorReferenceIdentification { get; set; }

	[Position(3)]
	public string ControllingAgencyCoded { get; set; }

	[Position(4)]
	public string ResponderControlReference { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S302_DialogueReference>(this);
		validator.Required(x=>x.InitiatorControlReference);
		validator.Length(x => x.InitiatorControlReference, 1, 35);
		validator.Length(x => x.InitiatorReferenceIdentification, 1, 35);
		validator.Length(x => x.ControllingAgencyCoded, 1, 3);
		validator.Length(x => x.ResponderControlReference, 1, 35);
		return validator.Results;
	}
}
