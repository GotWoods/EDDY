using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("RFF")]
public class RFF_Reference : EdifactSegment
{
	[Position(1)]
	public C506_Reference Reference { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RFF_Reference>(this);
		validator.Required(x=>x.Reference);
		return validator.Results;
	}
}
