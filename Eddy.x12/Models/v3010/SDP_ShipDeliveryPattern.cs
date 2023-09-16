using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("SDP")]
public class SDP_ShipDeliveryPattern : EdiX12Segment
{
	[Position(01)]
	public string ShipDeliveryPatternCode { get; set; }

	[Position(02)]
	public string ShipDeliveryPatternTimeCode { get; set; }

	[Position(03)]
	public string ShipDeliveryPatternCode2 { get; set; }

	[Position(04)]
	public string ShipDeliveryPatternTimeCode2 { get; set; }

	[Position(05)]
	public string ShipDeliveryPatternCode3 { get; set; }

	[Position(06)]
	public string ShipDeliveryPatternTimeCode3 { get; set; }

	[Position(07)]
	public string ShipDeliveryPatternCode4 { get; set; }

	[Position(08)]
	public string ShipDeliveryPatternTimeCode4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SDP_ShipDeliveryPattern>(this);
		validator.Required(x=>x.ShipDeliveryPatternCode);
		validator.Required(x=>x.ShipDeliveryPatternTimeCode);
		validator.Length(x => x.ShipDeliveryPatternCode, 1, 2);
		validator.Length(x => x.ShipDeliveryPatternTimeCode, 1);
		validator.Length(x => x.ShipDeliveryPatternCode2, 1, 2);
		validator.Length(x => x.ShipDeliveryPatternTimeCode2, 1);
		validator.Length(x => x.ShipDeliveryPatternCode3, 1, 2);
		validator.Length(x => x.ShipDeliveryPatternTimeCode3, 1);
		validator.Length(x => x.ShipDeliveryPatternCode4, 1, 2);
		validator.Length(x => x.ShipDeliveryPatternTimeCode4, 1);
		return validator.Results;
	}
}
