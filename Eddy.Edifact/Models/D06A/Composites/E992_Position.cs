using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D06A.Composites;

[Segment("E992")]
public class E992_Position : EdifactComponent
{
	[Position(1)]
	public string FirstRelatedLocationIdentifier { get; set; }

	[Position(2)]
	public string SecondRelatedLocationIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E992_Position>(this);
		validator.Length(x => x.FirstRelatedLocationIdentifier, 1, 35);
		validator.Length(x => x.SecondRelatedLocationIdentifier, 1, 35);
		return validator.Results;
	}
}
