using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._811;

public class LN1__LLX_LAMT {
	[SectionPosition(1)] public AMT_MonetaryAmount MonetaryAmount { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1__LLX_LAMT>(this);
		validator.Required(x => x.MonetaryAmount);
		return validator.Results;
	}
}
