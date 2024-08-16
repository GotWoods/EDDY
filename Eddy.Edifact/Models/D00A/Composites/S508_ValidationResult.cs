using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S508")]
public class S508_ValidationResult : EdifactComponent
{
	[Position(1)]
	public string ValidationValueQualifier { get; set; }

	[Position(2)]
	public string ValidationValue { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S508_ValidationResult>(this);
		validator.Required(x=>x.ValidationValueQualifier);
		validator.Length(x => x.ValidationValueQualifier, 1, 3);
		validator.Length(x => x.ValidationValue, 1, 512);
		return validator.Results;
	}
}
