using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Finance.v7030._811;

public class LHL__LSLN_LQTY {
	[SectionPosition(1)] public QTY_QuantityInformation QuantityInformation { get; set; } = new();
	[SectionPosition(2)] public SI_ServiceCharacteristicIdentification? ServiceCharacteristicIdentification { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LSLN_LQTY>(this);
		validator.Required(x => x.QuantityInformation);
		return validator.Results;
	}
}
