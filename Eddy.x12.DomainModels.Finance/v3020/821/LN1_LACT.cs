using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Finance.v3020._821;

public class LN1_LACT {
	[SectionPosition(1)] public ACT_AccountIdentification AccountIdentification { get; set; } = new();
	[SectionPosition(2)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(3)] public List<BAL_BalanceDetail> BalanceDetail { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1_LACT>(this);
		validator.Required(x => x.AccountIdentification);
		validator.CollectionSize(x => x.BalanceDetail, 1, 2147483647);
		return validator.Results;
	}
}
