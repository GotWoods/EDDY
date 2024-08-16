using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("PTY")]
public class PTY_Priority : EdifactSegment
{
	[Position(1)]
	public string PriorityTypeCodeQualifier { get; set; }

	[Position(2)]
	public C585_PriorityDetails PriorityDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PTY_Priority>(this);
		validator.Required(x=>x.PriorityTypeCodeQualifier);
		validator.Length(x => x.PriorityTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
