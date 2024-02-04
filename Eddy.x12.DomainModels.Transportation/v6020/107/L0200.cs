using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Transportation.v6020._107;

public class L0200 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(4)] public List<PR_ProductCommodity> ProductCommodity { get; set; } = new();
	[SectionPosition(5)] public ID4_LoadDetails? LoadDetails { get; set; }
	[SectionPosition(6)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(7)] public List<L0200_L0205> L0205 {get;set;} = new();
	[SectionPosition(8)] public List<L0200_L0210> L0210 {get;set;} = new();
	[SectionPosition(9)] public List<L0200_L0230> L0230 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.Geography, 1, 999);
		validator.CollectionSize(x => x.ProductCommodity, 0, 99);
		validator.CollectionSize(x => x.BillOfLadingHandlingRequirements, 0, 99);
		validator.CollectionSize(x => x.L0230, 1, 99999);
		foreach (var item in L0205) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0210) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0230) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
