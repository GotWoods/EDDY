using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Models.D01C;

[Segment("AUT")]
public class AUT_AuthenticationResult : EdifactSegment
{
	[Position(1)]
	public string ValidationResultText { get; set; }

	[Position(2)]
	public string ValidationKeyIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AUT_AuthenticationResult>(this);
		validator.Required(x=>x.ValidationResultText);
		validator.Length(x => x.ValidationResultText, 1, 35);
		validator.Length(x => x.ValidationKeyIdentifier, 1, 35);
		return validator.Results;
	}
}
