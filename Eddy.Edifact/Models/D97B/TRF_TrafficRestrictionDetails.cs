using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Models.D97B;

[Segment("TRF")]
public class TRF_TrafficRestrictionDetails : EdifactSegment
{
	[Position(1)]
	public E007_TrafficRestrictionDetails TrafficRestrictionDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TRF_TrafficRestrictionDetails>(this);
		validator.Required(x=>x.TrafficRestrictionDetails);
		return validator.Results;
	}
}
