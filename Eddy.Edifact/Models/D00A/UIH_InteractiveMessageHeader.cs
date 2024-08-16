using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UIH")]
public class UIH_InteractiveMessageHeader : EdifactSegment
{
	[Position(1)]
	public S306_InteractiveMessageIdentifier InteractiveMessageIdentifier { get; set; }

	[Position(2)]
	public string InteractiveMessageReferenceNumber { get; set; }

	[Position(3)]
	public S302_DialogueReference DialogueReference { get; set; }

	[Position(4)]
	public S301_StatusOfTransferInteractive StatusOfTransferInteractive { get; set; }

	[Position(5)]
	public S300_DateAndOrTimeOfInitiation DateAndOrTimeOfInitiation { get; set; }

	[Position(6)]
	public string TestIndicator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UIH_InteractiveMessageHeader>(this);
		validator.Required(x=>x.InteractiveMessageIdentifier);
		validator.Length(x => x.InteractiveMessageReferenceNumber, 1, 35);
		validator.Length(x => x.TestIndicator, 1);
		return validator.Results;
	}
}
