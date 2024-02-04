using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._426;

public class L1000__L1500_L1510 {
	[SectionPosition(1)] public L0_LineItemQuantityAndWeight LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(2)] public List<L1_RateAndCharges> RateAndCharges { get; set; } = new();
	[SectionPosition(3)] public L1A_BillingIdentification? BillingIdentification { get; set; }
	[SectionPosition(4)] public L7_TariffReference? TariffReference { get; set; }
	[SectionPosition(5)] public L7A_ContractReferenceIdentifier? ContractReferenceIdentifier { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L1000__L1500_L1510>(this);
		validator.Required(x => x.LineItemQuantityAndWeight);
		validator.CollectionSize(x => x.RateAndCharges, 0, 10);
		return validator.Results;
	}
}
