using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Transportation.v4030._218;

public class L2700 {
	[SectionPosition(1)] public SCL_RateBasisScales RateBasisScales { get; set; } = new();
	[SectionPosition(2)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(3)] public List<L2700_L2710> L2710 {get;set;} = new();
	[SectionPosition(4)] public LE_LoopTrailer? LoopTrailer { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2700>(this);
		validator.Required(x => x.RateBasisScales);
		validator.CollectionSize(x => x.L2710, 0, 9999);
		foreach (var item in L2710) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
