using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SMD")]
public class SMD_ConsolidatedShipmentManifestData : EdiX12Segment
{
	[Position(01)]
	public string ServiceLevelCode { get; set; }

	[Position(02)]
	public string ShipmentMethodOfPaymentCode { get; set; }

	[Position(03)]
	public string PickupOrDeliveryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SMD_ConsolidatedShipmentManifestData>(this);
		validator.Required(x=>x.ServiceLevelCode);
		validator.Required(x=>x.ShipmentMethodOfPaymentCode);
		validator.Length(x => x.ServiceLevelCode, 2);
		validator.Length(x => x.ShipmentMethodOfPaymentCode, 2);
		validator.Length(x => x.PickupOrDeliveryCode, 1, 2);
		return validator.Results;
	}
}
