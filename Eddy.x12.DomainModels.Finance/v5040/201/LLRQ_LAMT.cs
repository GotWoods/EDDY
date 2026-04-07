using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._201;

public class LLRQ_LAMT {
	[SectionPosition(1)] public AMT_MonetaryAmountInformation MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(2)] public MSG_MessageText? MessageText { get; set; }
	[SectionPosition(3)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLRQ_LAMT>(this);
		validator.Required(x => x.MonetaryAmountInformation);
		validator.CollectionSize(x => x.PercentAmounts, 1, 2147483647);
		return validator.Results;
	}
}
