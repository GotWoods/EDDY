using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("DTM")]
public class DTM_DateTimePeriod : EdifactSegment
{
	[Position(1)]
	public C507_DateTimePeriod DateTimePeriod { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DTM_DateTimePeriod>(this);
		validator.Required(x=>x.DateTimePeriod);
		return validator.Results;
	}
}
