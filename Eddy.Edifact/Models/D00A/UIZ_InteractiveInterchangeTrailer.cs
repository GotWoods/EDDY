using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("UIZ")]
public class UIZ_InteractiveInterchangeTrailer : EdifactSegment
{
	[Position(1)]
	public S302_DialogueReference DialogueReference { get; set; }

	[Position(2)]
	public string InterchangeControlCount { get; set; }

	[Position(3)]
	public string DuplicateIndicator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UIZ_InteractiveInterchangeTrailer>(this);
		validator.Length(x => x.InterchangeControlCount, 1, 6);
		validator.Length(x => x.DuplicateIndicator, 1);
		return validator.Results;
	}
}
