using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("G06")]
public class G06_ReceivingIdentification : EdiX12Segment
{
	[Position(01)]
	public string VendorOrderNumber { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(04)]
	public string PurchaseOrderNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G06_ReceivingIdentification>(this);
		validator.Required(x=>x.VendorOrderNumber);
		validator.Required(x=>x.Date);
		validator.Required(x=>x.ShipmentIdentificationNumber);
		validator.Required(x=>x.PurchaseOrderNumber);
		validator.Length(x => x.VendorOrderNumber, 1, 22);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		return validator.Results;
	}
}
