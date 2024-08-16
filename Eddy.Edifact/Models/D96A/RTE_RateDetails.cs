using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("RTE")]
public class RTE_RateDetails : EdifactSegment
{
	[Position(1)]
	public C128_RateDetails RateDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RTE_RateDetails>(this);
		validator.Required(x=>x.RateDetails);
		return validator.Results;
	}
}
