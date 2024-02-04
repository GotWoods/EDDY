using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Transportation.v8020._355;

public class LP4__LLX__LVID__LN10_LH1 {
	[SectionPosition(1)] public H1_HazardousMaterial HazardousMaterial { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	[SectionPosition(3)] public List<LP4__LLX__LVID__LN10__LH1_LH2> LH2 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX__LVID__LN10_LH1>(this);
		validator.Required(x => x.HazardousMaterial);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		validator.CollectionSize(x => x.LH2, 0, 99);
		foreach (var item in LH2) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
