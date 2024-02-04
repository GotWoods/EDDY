using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Transportation.v5020._223;

public class L4000__L4500_L4510 {
	[SectionPosition(1)] public CSD_ConsolidatedShipmentInvoiceData ConsolidatedShipmentInvoiceData { get; set; } = new();
	[SectionPosition(2)] public AT8_ShipmentWeightPackagingAndQuantityData? ShipmentWeightPackagingAndQuantityData { get; set; }
	[SectionPosition(3)] public List<L1_RateAndCharges> RateAndCharges { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L4000__L4500_L4510>(this);
		validator.Required(x => x.ConsolidatedShipmentInvoiceData);
		validator.CollectionSize(x => x.RateAndCharges, 0, 10);
		return validator.Results;
	}
}
