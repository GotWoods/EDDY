using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SDP")]
public class SDP_ShipDeliveryPattern : EdiX12Segment
{
	[Position(01)]
	public string ShipDeliveryOrCalendarPatternCode { get; set; }

	[Position(02)]
	public string ShipDeliveryPatternTimeCode { get; set; }

	[Position(03)]
	public string ShipDeliveryOrCalendarPatternCode2 { get; set; }

	[Position(04)]
	public string ShipDeliveryPatternTimeCode2 { get; set; }

	[Position(05)]
	public string ShipDeliveryOrCalendarPatternCode3 { get; set; }

	[Position(06)]
	public string ShipDeliveryPatternTimeCode3 { get; set; }

	[Position(07)]
	public string ShipDeliveryOrCalendarPatternCode4 { get; set; }

	[Position(08)]
	public string ShipDeliveryPatternTimeCode4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SDP_ShipDeliveryPattern>(this);
		validator.Required(x=>x.ShipDeliveryOrCalendarPatternCode);
		validator.Required(x=>x.ShipDeliveryPatternTimeCode);
		validator.Length(x => x.ShipDeliveryOrCalendarPatternCode, 1, 2);
		validator.Length(x => x.ShipDeliveryPatternTimeCode, 1);
		validator.Length(x => x.ShipDeliveryOrCalendarPatternCode2, 1, 2);
		validator.Length(x => x.ShipDeliveryPatternTimeCode2, 1);
		validator.Length(x => x.ShipDeliveryOrCalendarPatternCode3, 1, 2);
		validator.Length(x => x.ShipDeliveryPatternTimeCode3, 1);
		validator.Length(x => x.ShipDeliveryOrCalendarPatternCode4, 1, 2);
		validator.Length(x => x.ShipDeliveryPatternTimeCode4, 1);
		return validator.Results;
	}
}
