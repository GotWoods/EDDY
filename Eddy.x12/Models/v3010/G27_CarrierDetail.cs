using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G27")]
public class G27_CarrierDetail : EdiX12Segment
{
	[Position(01)]
	public string TransportationMethodTypeCode { get; set; }

	[Position(02)]
	public string EquipmentInitial { get; set; }

	[Position(03)]
	public string EquipmentNumber { get; set; }

	[Position(04)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(05)]
	public string Routing { get; set; }

	[Position(06)]
	public string ShipmentOrderStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G27_CarrierDetail>(this);
		validator.Required(x=>x.TransportationMethodTypeCode);
		validator.Length(x => x.TransportationMethodTypeCode, 1, 2);
		validator.Length(x => x.EquipmentInitial, 1, 4);
		validator.Length(x => x.EquipmentNumber, 1, 10);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.Routing, 1, 35);
		validator.Length(x => x.ShipmentOrderStatusCode, 2);
		return validator.Results;
	}
}
