using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._602;

public class L0300 {
	[SectionPosition(1)] public SB_DocketLevel DocketLevel { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public List<L0300_L0310> L0310 {get;set;} = new();
	[SectionPosition(4)] public List<L0300_L0320> L0320 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300>(this);
		validator.Required(x => x.DocketLevel);
		validator.CollectionSize(x => x.Geography, 0, 999);
		validator.CollectionSize(x => x.L0310, 0, 400);
		validator.CollectionSize(x => x.L0320, 0, 999);
		foreach (var item in L0310) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0320) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
