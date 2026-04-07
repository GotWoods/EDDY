using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Finance.v3020._822;

public class LN1__LACT_LBAL {
	[SectionPosition(1)] public BAL_BalanceDetail BalanceDetail { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1__LACT_LBAL>(this);
		validator.Required(x => x.BalanceDetail);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 25);
		validator.CollectionSize(x => x.DateTimeReference, 0, 5);
		return validator.Results;
	}
}
