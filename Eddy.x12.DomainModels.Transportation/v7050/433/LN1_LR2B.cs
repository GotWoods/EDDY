using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Transportation.v7050._433;

public class LN1_LR2B {
	[SectionPosition(1)] public R2B_JunctionsAndProportions JunctionsAndProportions { get; set; } = new();
	[SectionPosition(2)] public SWC_SwitchingConditions? SwitchingConditions { get; set; }
	[SectionPosition(3)] public List<PR_ProductCommodity> ProductCommodity { get; set; } = new();
	[SectionPosition(4)] public SWR_SwitchingRates? SwitchingRates { get; set; }
	[SectionPosition(5)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(6)] public List<CD_ShipmentConditions> ShipmentConditions { get; set; } = new();
	[SectionPosition(7)] public List<XD_PlacementPullData> PlacementPullData { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1_LR2B>(this);
		validator.Required(x => x.JunctionsAndProportions);
		validator.CollectionSize(x => x.ProductCommodity, 0, 200);
		validator.CollectionSize(x => x.ShipmentConditions, 0, 160);
		validator.CollectionSize(x => x.PlacementPullData, 0, 2);
		return validator.Results;
	}
}
