using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B.Composites;

namespace Eddy.Edifact.Models.D98B;

[Segment("EVT")]
public class EVT_Event : EdifactSegment
{
	[Position(1)]
	public C030_EventType EventType { get; set; }

	[Position(2)]
	public C063_EventIdentification EventIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EVT_Event>(this);
		return validator.Results;
	}
}
