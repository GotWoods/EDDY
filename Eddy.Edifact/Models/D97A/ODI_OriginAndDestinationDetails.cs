using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("ODI")]
public class ODI_OriginAndDestinationDetails : EdifactSegment
{
	[Position(1)]
	public string PlaceLocationIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ODI_OriginAndDestinationDetails>(this);
		validator.Length(x => x.PlaceLocationIdentification, 1, 25);
		return validator.Results;
	}
}
