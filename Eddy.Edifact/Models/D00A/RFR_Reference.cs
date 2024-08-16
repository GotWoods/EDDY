using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("RFR")]
public class RFR_Reference : EdifactSegment
{
	[Position(1)]
	public E506_Reference Reference { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RFR_Reference>(this);
		validator.Required(x=>x.Reference);
		return validator.Results;
	}
}
