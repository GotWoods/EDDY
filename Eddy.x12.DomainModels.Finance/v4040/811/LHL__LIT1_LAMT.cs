using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._811;

public class LHL__LIT1_LAMT {
	[SectionPosition(1)] public AMT_MonetaryAmount MonetaryAmount { get; set; } = new();
	[SectionPosition(2)] public CUR_Currency? Currency { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LIT1_LAMT>(this);
		validator.Required(x => x.MonetaryAmount);
		return validator.Results;
	}
}
