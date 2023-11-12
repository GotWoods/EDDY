using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("BDD")]
public class BDD_BeginningSegmentForShipmentDeliveryDiscrepancyInformation : EdiX12Segment
{
	[Position(01)]
	public string InvoiceNumber { get; set; }

	[Position(02)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(03)]
	public string ShipmentIdentificationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<BDD_BeginningSegmentForShipmentDeliveryDiscrepancyInformation>(this);
		validator.Required(x=>x.InvoiceNumber);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Length(x => x.InvoiceNumber, 1, 22);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		return validator.Results;
	}
}
