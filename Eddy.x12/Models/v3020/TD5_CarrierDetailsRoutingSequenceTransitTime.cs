using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("TD5")]
public class TD5_CarrierDetailsRoutingSequenceTransitTime : EdiX12Segment
{
	[Position(01)]
	public string RoutingSequenceCode { get; set; }

	[Position(02)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(03)]
	public string IdentificationCode { get; set; }

	[Position(04)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(05)]
	public string Routing { get; set; }

	[Position(06)]
	public string ShipmentOrderStatusCode { get; set; }

	[Position(07)]
	public string LocationQualifier { get; set; }

	[Position(08)]
	public string LocationIdentifier { get; set; }

	[Position(09)]
	public string TransitDirectionCode { get; set; }

	[Position(10)]
	public string TransitTimeDirectionQualifier { get; set; }

	[Position(11)]
	public decimal? TransitTime { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TD5_CarrierDetailsRoutingSequenceTransitTime>(this);
		validator.ARequiresB(x=>x.IdentificationCodeQualifier, x=>x.IdentificationCode);
		validator.ARequiresB(x=>x.LocationQualifier, x=>x.LocationIdentifier);
		validator.ARequiresB(x=>x.TransitTimeDirectionQualifier, x=>x.TransitTime);
		validator.Length(x => x.RoutingSequenceCode, 1, 2);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 17);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.Routing, 1, 35);
		validator.Length(x => x.ShipmentOrderStatusCode, 2);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		validator.Length(x => x.TransitDirectionCode, 2);
		validator.Length(x => x.TransitTimeDirectionQualifier, 2);
		validator.Length(x => x.TransitTime, 1, 4);
		return validator.Results;
	}
}
