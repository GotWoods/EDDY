using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._218;

public class LSCL {
	[SectionPosition(1)] public SCL_RateBasisScales RateBasisScales { get; set; } = new();
	[SectionPosition(2)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(3)] public List<LSCL_LCL> LCL {get;set;} = new();
	[SectionPosition(4)] public LE_LoopTrailer? LoopTrailer { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSCL>(this);
		validator.Required(x => x.RateBasisScales);
		validator.CollectionSize(x => x.LCL, 0, 9999);
		foreach (var item in LCL) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
