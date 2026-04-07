using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._811;

public class LHL__LIT1_LQTY {
	[SectionPosition(1)] public QTY_Quantity Quantity { get; set; } = new();
	[SectionPosition(2)] public SI_ServiceCharacteristicIdentification? ServiceCharacteristicIdentification { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LIT1_LQTY>(this);
		validator.Required(x => x.Quantity);
		return validator.Results;
	}
}
