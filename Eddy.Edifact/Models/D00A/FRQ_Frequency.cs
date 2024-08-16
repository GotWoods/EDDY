using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("FRQ")]
public class FRQ_Frequency : EdifactSegment
{
	[Position(1)]
	public E520_Frequency Frequency { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FRQ_Frequency>(this);
		validator.Required(x=>x.Frequency);
		return validator.Results;
	}
}
