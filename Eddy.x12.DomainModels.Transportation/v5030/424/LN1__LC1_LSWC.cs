using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Transportation.v5030._424;

public class LN1__LC1_LSWC {
	[SectionPosition(1)] public SWC_SwitchingConditions SwitchingConditions { get; set; } = new();
	[SectionPosition(2)] public List<LN1__LC1__LSWC_LED> LED {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1__LC1_LSWC>(this);
		validator.Required(x => x.SwitchingConditions);
		validator.CollectionSize(x => x.LED, 0, 9999);
		foreach (var item in LED) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
