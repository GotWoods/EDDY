using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G50")]
public class G50_PurchaseOrderIdentification : EdiX12Segment
{
	[Position(01)]
	public string OrderStatusCode { get; set; }

	[Position(02)]
	public string PurchaseOrderDate { get; set; }

	[Position(03)]
	public string PurchaseOrderNumber { get; set; }

	[Position(04)]
	public string TaxExemptCode { get; set; }

	[Position(05)]
	public string MasterReferenceLinkNumber { get; set; }

	[Position(06)]
	public int? LinkSequenceNumber { get; set; }

	[Position(07)]
	public string PurchaseOrderTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G50_PurchaseOrderIdentification>(this);
		validator.Required(x=>x.OrderStatusCode);
		validator.Required(x=>x.PurchaseOrderDate);
		validator.Required(x=>x.PurchaseOrderNumber);
		validator.Length(x => x.OrderStatusCode, 1);
		validator.Length(x => x.PurchaseOrderDate, 6);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.TaxExemptCode, 1);
		validator.Length(x => x.MasterReferenceLinkNumber, 1, 22);
		validator.Length(x => x.LinkSequenceNumber, 6);
		validator.Length(x => x.PurchaseOrderTypeCode, 2);
		return validator.Results;
	}
}
