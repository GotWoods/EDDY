using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("ODI")]
public class ODI_OriginAndDestinationDetails : EdifactSegment
{
	[Position(1)]
	public string LocationNameCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ODI_OriginAndDestinationDetails>(this);
		validator.Length(x => x.LocationNameCode, 1, 25);
		return validator.Results;
	}
}
