using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("GIS")]
public class GIS_GeneralIndicator : EdifactSegment
{
	[Position(1)]
	public C529_ProcessingIndicator ProcessingIndicator { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<GIS_GeneralIndicator>(this);
		validator.Required(x=>x.ProcessingIndicator);
		return validator.Results;
	}
}
