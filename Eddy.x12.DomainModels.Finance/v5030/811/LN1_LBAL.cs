using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Finance.v5030._811;

public class LN1_LBAL {
	[SectionPosition(1)] public BAL_BalanceDetail BalanceDetail { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1_LBAL>(this);
		validator.Required(x => x.BalanceDetail);
		return validator.Results;
	}
}
