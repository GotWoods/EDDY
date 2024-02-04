using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._212;

public class L0200_L0210 {
	[SectionPosition(1)] public SPO_ShipmentPurchaseOrderDetail ShipmentPurchaseOrderDetail { get; set; } = new();
	[SectionPosition(2)] public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0210>(this);
		validator.Required(x => x.ShipmentPurchaseOrderDetail);
		validator.CollectionSize(x => x.DestinationQuantity, 0, 9999);
		return validator.Results;
	}
}
