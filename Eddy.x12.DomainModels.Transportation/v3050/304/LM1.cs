using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._304;

public class LM1 {
	[SectionPosition(1)] public M1_Insurance Insurance { get; set; } = new();
	[SectionPosition(2)] public CUR_Currency? Currency { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LM1>(this);
		validator.Required(x => x.Insurance);
		return validator.Results;
	}
}
