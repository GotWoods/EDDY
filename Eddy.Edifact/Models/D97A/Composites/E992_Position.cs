using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97A.Composites;

[Segment("E992")]
public class E992_Position : EdifactComponent
{
	[Position(1)]
	public string RelatedPlaceLocationOneIdentification { get; set; }

	[Position(2)]
	public string RelatedPlaceLocationTwoIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E992_Position>(this);
		validator.Length(x => x.RelatedPlaceLocationOneIdentification, 1, 25);
		validator.Length(x => x.RelatedPlaceLocationTwoIdentification, 1, 25);
		return validator.Results;
	}
}
