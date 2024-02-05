using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._218;

public class L2300 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(4)] public List<L2300_L2310> L2310 {get;set;} = new();
	[SectionPosition(5)] public LE_LoopTrailer? LoopTrailer { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2300>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.Geography, 0, 99);
		validator.CollectionSize(x => x.L2310, 0, 99999);
		foreach (var item in L2310) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
