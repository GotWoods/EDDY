using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Finance.v6050._811;

public class LHL__LTCD_LQTY {
	[SectionPosition(1)] public QTY_QuantityInformation QuantityInformation { get; set; } = new();
	[SectionPosition(2)] public SI_ServiceCharacteristicIdentification? ServiceCharacteristicIdentification { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LTCD_LQTY>(this);
		validator.Required(x => x.QuantityInformation);
		return validator.Results;
	}
}
