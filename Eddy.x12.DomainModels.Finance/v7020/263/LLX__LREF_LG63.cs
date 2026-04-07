using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._263;

public class LLX__LREF_LG63 {
	[SectionPosition(1)] public G63_Period Period { get; set; } = new();
	[SectionPosition(2)] public PCT_PercentAmounts? PercentAmounts { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LREF_LG63>(this);
		validator.Required(x => x.Period);
		return validator.Results;
	}
}
