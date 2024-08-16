using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S306")]
public class S306_InteractiveMessageIdentifier : EdifactComponent
{
	[Position(1)]
	public string MessageType { get; set; }

	[Position(2)]
	public string MessageVersionNumber { get; set; }

	[Position(3)]
	public string MessageReleaseNumber { get; set; }

	[Position(4)]
	public string MessageTypeSubFunctionIdentification { get; set; }

	[Position(5)]
	public string ControllingAgencyCoded { get; set; }

	[Position(6)]
	public string AssociationAssignedCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S306_InteractiveMessageIdentifier>(this);
		validator.Required(x=>x.MessageType);
		validator.Required(x=>x.MessageVersionNumber);
		validator.Required(x=>x.MessageReleaseNumber);
		validator.Length(x => x.MessageType, 1, 6);
		validator.Length(x => x.MessageVersionNumber, 1, 3);
		validator.Length(x => x.MessageReleaseNumber, 1, 3);
		validator.Length(x => x.MessageTypeSubFunctionIdentification, 1, 6);
		validator.Length(x => x.ControllingAgencyCoded, 1, 3);
		validator.Length(x => x.AssociationAssignedCode, 1, 6);
		return validator.Results;
	}
}
