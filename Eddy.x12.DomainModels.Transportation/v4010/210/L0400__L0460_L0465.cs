using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._210;

public class L0400__L0460_L0465 {
	[SectionPosition(1)] public SPO_ShipmentPurchaseOrderDetail ShipmentPurchaseOrderDetail { get; set; } = new();
	[SectionPosition(2)] public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400__L0460_L0465>(this);
		validator.Required(x => x.ShipmentPurchaseOrderDetail);
		validator.CollectionSize(x => x.DestinationQuantity, 0, 10);
		return validator.Results;
	}
}
