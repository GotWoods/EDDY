using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._223;

public class L4000_L4100 {
	[SectionPosition(1)] public SPO_ShipmentPurchaseOrderDetail ShipmentPurchaseOrderDetail { get; set; } = new();
	[SectionPosition(2)] public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L4000_L4100>(this);
		validator.Required(x => x.ShipmentPurchaseOrderDetail);
		validator.CollectionSize(x => x.DestinationQuantity, 0, 10);
		return validator.Results;
	}
}