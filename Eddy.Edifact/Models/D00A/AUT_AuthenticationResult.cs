using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("AUT")]
public class AUT_AuthenticationResult : EdifactSegment
{
	[Position(1)]
	public string ValidationResultValue { get; set; }

	[Position(2)]
	public string ValidationKeyIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AUT_AuthenticationResult>(this);
		validator.Required(x=>x.ValidationResultValue);
		validator.Length(x => x.ValidationResultValue, 1, 35);
		validator.Length(x => x.ValidationKeyIdentifier, 1, 35);
		return validator.Results;
	}
}
