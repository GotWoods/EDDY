using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Transportation.v4030._494;

public class LR9 {
	[SectionPosition(1)] public R9_RouteCode RouteCode { get; set; } = new();
	[SectionPosition(2)] public List<LR9_LR2B> LR2B {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LR9>(this);
		validator.Required(x => x.RouteCode);
		validator.CollectionSize(x => x.LR2B, 0, 10);
		foreach (var item in LR2B) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
