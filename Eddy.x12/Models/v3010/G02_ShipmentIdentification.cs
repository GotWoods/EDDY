using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G02")]
public class G02_ShipmentIdentification : EdiX12Segment
{
	[Position(01)]
	public string VendorOrderNumber { get; set; }

	[Position(02)]
	public string ShipmentDate { get; set; }

	[Position(03)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(04)]
	public string PurchaseOrderNumber { get; set; }

	[Position(05)]
	public string MasterReferenceLinkNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G02_ShipmentIdentification>(this);
		validator.Required(x=>x.VendorOrderNumber);
		validator.Required(x=>x.ShipmentDate);
		validator.Required(x=>x.ShipmentIdentificationNumber);
		validator.Required(x=>x.PurchaseOrderNumber);
		validator.Length(x => x.VendorOrderNumber, 1, 22);
		validator.Length(x => x.ShipmentDate, 6);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.MasterReferenceLinkNumber, 1, 22);
		return validator.Results;
	}
}
