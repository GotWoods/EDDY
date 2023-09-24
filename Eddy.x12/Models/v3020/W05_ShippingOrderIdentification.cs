using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("W05")]
public class W05_ShippingOrderIdentification : EdiX12Segment
{
	[Position(01)]
	public string OrderStatusCode { get; set; }

	[Position(02)]
	public string DepositorOrderNumber { get; set; }

	[Position(03)]
	public string PurchaseOrderNumber { get; set; }

	[Position(04)]
	public int? LinkSequenceNumber { get; set; }

	[Position(05)]
	public string MasterReferenceLinkNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W05_ShippingOrderIdentification>(this);
		validator.Required(x=>x.OrderStatusCode);
		validator.Required(x=>x.DepositorOrderNumber);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LinkSequenceNumber, x=>x.MasterReferenceLinkNumber);
		validator.Length(x => x.OrderStatusCode, 1);
		validator.Length(x => x.DepositorOrderNumber, 1, 22);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.LinkSequenceNumber, 6);
		validator.Length(x => x.MasterReferenceLinkNumber, 1, 22);
		return validator.Results;
	}
}
