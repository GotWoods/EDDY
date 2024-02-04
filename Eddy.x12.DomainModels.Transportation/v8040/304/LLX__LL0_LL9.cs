using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._304;

public class LLX__LL0_LL9 {
	[SectionPosition(1)] public L9_ChargeDetail ChargeDetail { get; set; } = new();
	[SectionPosition(2)] public CUR_Currency? Currency { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LL0_LL9>(this);
		validator.Required(x => x.ChargeDetail);
		return validator.Results;
	}
}
