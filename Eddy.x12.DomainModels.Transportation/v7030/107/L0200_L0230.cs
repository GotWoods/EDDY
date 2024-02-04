using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Transportation.v7030._107;

public class L0200_L0230 {
	[SectionPosition(1)] public CA1_RateRequestIdentifier RateRequestIdentifier { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public List<PR_ProductCommodity> ProductCommodity { get; set; } = new();
	[SectionPosition(4)] public ID4_LoadDetails? LoadDetails { get; set; }
	[SectionPosition(5)] public IV1_LaneEstimates? LaneEstimates { get; set; }
	[SectionPosition(6)] public SV_ServiceDescription? ServiceDescription { get; set; }
	[SectionPosition(7)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(8)] public List<MCT_TariffAccessorialCharges> TariffAccessorialCharges { get; set; } = new();
	[SectionPosition(9)] public List<L0200__L0230_L0232> L0232 {get;set;} = new();
	[SectionPosition(10)] public List<L0200__L0230_L0235> L0235 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0230>(this);
		validator.Required(x => x.RateRequestIdentifier);
		validator.CollectionSize(x => x.Geography, 1, 999);
		validator.CollectionSize(x => x.ProductCommodity, 0, 99);
		validator.CollectionSize(x => x.BillOfLadingHandlingRequirements, 0, 99);
		validator.CollectionSize(x => x.TariffAccessorialCharges, 0, 999);
		foreach (var item in L0232) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0235) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
