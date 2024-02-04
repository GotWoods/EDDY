using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._426;

public class LBNX_LR2B {
	[SectionPosition(1)] public R2B_JunctionsAndProportions JunctionsAndProportions { get; set; } = new();
	[SectionPosition(2)] public List<R2C_DivisionBasis> DivisionBasis { get; set; } = new();
	[SectionPosition(3)] public List<R2D_MiscellaneousCharge> MiscellaneousCharge { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LBNX_LR2B>(this);
		validator.Required(x => x.JunctionsAndProportions);
		validator.CollectionSize(x => x.DivisionBasis, 0, 12);
		validator.CollectionSize(x => x.MiscellaneousCharge, 0, 5);
		return validator.Results;
	}
}
