using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Transportation.v4030._494;

public class LR9_LR2B {
	[SectionPosition(1)] public R2B_JunctionsAndProportions JunctionsAndProportions { get; set; } = new();
	[SectionPosition(2)] public List<R2C_DivisionBasis> DivisionBasis { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LR9_LR2B>(this);
		validator.Required(x => x.JunctionsAndProportions);
		validator.CollectionSize(x => x.DivisionBasis, 0, 10);
		return validator.Results;
	}
}
