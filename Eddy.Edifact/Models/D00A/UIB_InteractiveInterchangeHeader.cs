using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UIB")]
public class UIB_InteractiveInterchangeHeader : EdifactSegment
{
	[Position(1)]
	public S001_SyntaxIdentifier SyntaxIdentifier { get; set; }

	[Position(2)]
	public S302_DialogueReference DialogueReference { get; set; }

	[Position(3)]
	public S303_TransactionReference TransactionReference { get; set; }

	[Position(4)]
	public S018_ScenarioIdentification ScenarioIdentification { get; set; }

	[Position(5)]
	public S305_DialogueIdentification DialogueIdentification { get; set; }

	[Position(6)]
	public S002_InterchangeSender InterchangeSender { get; set; }

	[Position(7)]
	public S003_InterchangeRecipient InterchangeRecipient { get; set; }

	[Position(8)]
	public S300_DateAndOrTimeOfInitiation DateAndOrTimeOfInitiation { get; set; }

	[Position(9)]
	public string DuplicateIndicator { get; set; }

	[Position(10)]
	public string TestIndicator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UIB_InteractiveInterchangeHeader>(this);
		validator.Required(x=>x.SyntaxIdentifier);
		validator.Length(x => x.DuplicateIndicator, 1);
		validator.Length(x => x.TestIndicator, 1);
		return validator.Results;
	}
}
