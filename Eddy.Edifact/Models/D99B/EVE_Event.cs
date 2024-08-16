using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Models.D99B;

[Segment("EVE")]
public class EVE_Event : EdifactSegment
{
	[Position(1)]
	public string EventDetailsCodeQualifier { get; set; }

	[Position(2)]
	public C004_EventCategory EventCategory { get; set; }

	[Position(3)]
	public C030_EventType EventType { get; set; }

	[Position(4)]
	public C063_EventIdentification EventIdentification { get; set; }

	[Position(5)]
	public string ActionRequestNotificationDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EVE_Event>(this);
		validator.Length(x => x.EventDetailsCodeQualifier, 1, 3);
		validator.Length(x => x.ActionRequestNotificationDescriptionCode, 1, 3);
		return validator.Results;
	}
}
