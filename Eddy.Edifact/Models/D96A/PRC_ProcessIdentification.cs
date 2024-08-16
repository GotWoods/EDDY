using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("PRC")]
public class PRC_ProcessIdentification : EdifactSegment
{
	[Position(1)]
	public C242_ProcessTypeAndDescription ProcessTypeAndDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRC_ProcessIdentification>(this);
		validator.Required(x=>x.ProcessTypeAndDescription);
		return validator.Results;
	}
}
