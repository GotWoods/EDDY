using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("AUT")]
public class AUT_AuthenticationResult : EdifactSegment
{
	[Position(1)]
	public string ValidationResult { get; set; }

	[Position(2)]
	public string ValidationKeyIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AUT_AuthenticationResult>(this);
		validator.Required(x=>x.ValidationResult);
		validator.Length(x => x.ValidationResult, 1, 35);
		validator.Length(x => x.ValidationKeyIdentification, 1, 35);
		return validator.Results;
	}
}
