using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5020;

[Segment("G88")]
public class G88_DeliveryReturnIdentificationAdjustment : EdiX12Segment
{
	[Position(01)]
	public string PhysicalDeliveryOrReturnDate { get; set; }

	[Position(02)]
	public string ProductOwnershipTransferDate { get; set; }

	[Position(03)]
	public string PurchaseOrderNumber { get; set; }

	[Position(04)]
	public string PurchaseOrderDate { get; set; }

	[Position(05)]
	public string ReceiversLocationNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G88_DeliveryReturnIdentificationAdjustment>(this);
		validator.Length(x => x.PhysicalDeliveryOrReturnDate, 8);
		validator.Length(x => x.ProductOwnershipTransferDate, 8);
		validator.Length(x => x.PurchaseOrderNumber, 1, 22);
		validator.Length(x => x.PurchaseOrderDate, 8);
		validator.Length(x => x.ReceiversLocationNumber, 1, 13);
		return validator.Results;
	}
}
