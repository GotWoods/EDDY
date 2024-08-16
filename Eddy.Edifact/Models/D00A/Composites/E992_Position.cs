using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E992")]
public class E992_Position : EdifactComponent
{
	[Position(1)]
	public string FirstRelatedLocationNameCode { get; set; }

	[Position(2)]
	public string SecondRelatedLocationNameCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E992_Position>(this);
		validator.Length(x => x.FirstRelatedLocationNameCode, 1, 25);
		validator.Length(x => x.SecondRelatedLocationNameCode, 1, 25);
		return validator.Results;
	}
}
