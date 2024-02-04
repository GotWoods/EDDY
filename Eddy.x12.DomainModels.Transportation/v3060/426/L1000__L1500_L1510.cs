using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._426;

public class L1000__L1500_L1510 {
	[SectionPosition(1)] public L0_LineItemQuantityAndWeight LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(3)] public List<L1_RateAndCharges> RateAndCharges { get; set; } = new();
	[SectionPosition(4)] public PI_PriceAuthorityIdentification? PriceAuthorityIdentification { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L1000__L1500_L1510>(this);
		validator.Required(x => x.LineItemQuantityAndWeight);
		validator.CollectionSize(x => x.Measurements, 0, 3);
		validator.CollectionSize(x => x.RateAndCharges, 0, 10);
		return validator.Results;
	}
}
