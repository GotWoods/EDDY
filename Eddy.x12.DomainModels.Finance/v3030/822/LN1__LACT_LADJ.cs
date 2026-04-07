using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._822;

public class LN1__LACT_LADJ {
	[SectionPosition(1)] public ADJ_AdjustmentsToBalancesOrServices AdjustmentsToBalancesOrServices { get; set; } = new();
	[SectionPosition(2)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1__LACT_LADJ>(this);
		validator.Required(x => x.AdjustmentsToBalancesOrServices);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 2);
		return validator.Results;
	}
}
