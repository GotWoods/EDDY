using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._460;

public class LSB__LSC__LLX_LR9 {
	[SectionPosition(1)] public R9_RouteCode RouteCode { get; set; } = new();
	[SectionPosition(2)] public List<FK_Factor> Factor { get; set; } = new();
	[SectionPosition(3)] public List<LSB__LSC__LLX__LR9_LR2B> LR2B {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSB__LSC__LLX_LR9>(this);
		validator.Required(x => x.RouteCode);
		validator.CollectionSize(x => x.Factor, 0, 13);
		validator.CollectionSize(x => x.LR2B, 0, 13);
		foreach (var item in LR2B) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
