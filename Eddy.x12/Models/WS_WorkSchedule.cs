using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("WS")]
public class WS_WorkSchedule : EdiX12Segment
{
	[Position(01)]
	public string ShipDeliveryOrCalendarPatternCode { get; set; }

	[Position(02)]
	public string Time { get; set; }

	[Position(03)]
	public string Time2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<WS_WorkSchedule>(this);
		validator.Required(x=>x.ShipDeliveryOrCalendarPatternCode);
		validator.Length(x => x.ShipDeliveryOrCalendarPatternCode, 1, 2);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.Time2, 4, 8);
		return validator.Results;
	}
}
