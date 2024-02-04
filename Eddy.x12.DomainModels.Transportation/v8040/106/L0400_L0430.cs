using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._106;

public class L0400_L0430 {
	[SectionPosition(1)] public CA1_RateRequestIdentifier RateRequestIdentifier { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public List<PR_ProductCommodity> ProductCommodity { get; set; } = new();
	[SectionPosition(4)] public LC1_LaneCommitments? LaneCommitments { get; set; }
	[SectionPosition(5)] public SV_ServiceDescription? ServiceDescription { get; set; }
	[SectionPosition(6)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(7)] public List<MCT_TariffAccessorialCharges> TariffAccessorialCharges { get; set; } = new();
	[SectionPosition(8)] public List<L0400__L0430_L0432> L0432 {get;set;} = new();
	[SectionPosition(9)] public List<L0400__L0430_L0434> L0434 {get;set;} = new();
	[SectionPosition(10)] public List<L0400__L0430_L0438> L0438 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400_L0430>(this);
		validator.Required(x => x.RateRequestIdentifier);
		validator.CollectionSize(x => x.Geography, 0, 999);
		validator.CollectionSize(x => x.ProductCommodity, 0, 99);
		validator.CollectionSize(x => x.BillOfLadingHandlingRequirements, 0, 99);
		validator.CollectionSize(x => x.TariffAccessorialCharges, 0, 999);
		validator.CollectionSize(x => x.L0434, 1, 999);
		foreach (var item in L0432) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0434) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0438) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
