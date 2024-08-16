using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("USR")]
public class USR_SecurityResult : EdifactSegment
{
	[Position(1)]
	public S508_ValidationResult ValidationResult { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USR_SecurityResult>(this);
		validator.Required(x=>x.ValidationResult);
		return validator.Results;
	}
}
