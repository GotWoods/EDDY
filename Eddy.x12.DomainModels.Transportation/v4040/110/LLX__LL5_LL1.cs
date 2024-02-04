using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._110;

public class LLX__LL5_LL1 {
	[SectionPosition(1)] public L1_RateAndCharges RateAndCharges { get; set; } = new();
	[SectionPosition(2)] public C3_Currency? Currency { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LL5_LL1>(this);
		validator.Required(x => x.RateAndCharges);
		return validator.Results;
	}
}
