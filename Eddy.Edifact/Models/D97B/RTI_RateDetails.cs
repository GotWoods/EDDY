using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Models.D97B;

[Segment("RTI")]
public class RTI_RateDetails : EdifactSegment
{
	[Position(1)]
	public E011_RateClassDetails RateClassDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RTI_RateDetails>(this);
		validator.Required(x=>x.RateClassDetails);
		return validator.Results;
	}
}
