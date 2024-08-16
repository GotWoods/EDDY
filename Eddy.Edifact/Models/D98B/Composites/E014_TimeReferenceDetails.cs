using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D98B.Composites;

[Segment("E014")]
public class E014_TimeReferenceDetails : EdifactComponent
{
	[Position(1)]
	public string ReferenceNumber { get; set; }

	[Position(2)]
	public string ReferenceQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E014_TimeReferenceDetails>(this);
		validator.Length(x => x.ReferenceNumber, 1, 35);
		validator.Length(x => x.ReferenceQualifier, 1, 3);
		return validator.Results;
	}
}
