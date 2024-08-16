using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("PTY")]
public class PTY_Priority : EdifactSegment
{
	[Position(1)]
	public string PriorityQualifier { get; set; }

	[Position(2)]
	public C585_PriorityDetails PriorityDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PTY_Priority>(this);
		validator.Required(x=>x.PriorityQualifier);
		validator.Length(x => x.PriorityQualifier, 1, 3);
		return validator.Results;
	}
}
