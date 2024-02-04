using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Transportation.v5050._106;

public class L0400 {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public List<PR_ProductCommodity> ProductCommodity { get; set; } = new();
	[SectionPosition(4)] public TFR_TariffRestrictions? TariffRestrictions { get; set; }
	[SectionPosition(5)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(6)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(7)] public List<L0400_L0405> L0405 {get;set;} = new();
	[SectionPosition(8)] public List<L0400_L0410> L0410 {get;set;} = new();
	[SectionPosition(9)] public List<L0400_L0430> L0430 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.Geography, 0, 999);
		validator.CollectionSize(x => x.ProductCommodity, 0, 99);
		validator.CollectionSize(x => x.BillOfLadingHandlingRequirements, 0, 99);
		validator.CollectionSize(x => x.L0430, 1, 99999);
		foreach (var item in L0405) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0410) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0430) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
