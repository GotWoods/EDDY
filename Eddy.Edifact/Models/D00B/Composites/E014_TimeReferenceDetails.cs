using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("E014")]
public class E014_TimeReferenceDetails : EdifactComponent
{
	[Position(1)]
	public string ReferenceIdentifier { get; set; }

	[Position(2)]
	public string ReferenceCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E014_TimeReferenceDetails>(this);
		validator.Length(x => x.ReferenceIdentifier, 1, 70);
		validator.Length(x => x.ReferenceCodeQualifier, 1, 3);
		return validator.Results;
	}
}
