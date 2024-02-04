using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;
using Eddy.x12.DomainModels.Transportation.v5010._107;

namespace Eddy.x12.DomainModels.Transportation.v5010;

public class Edi107_RequestForMotorCarrierRateProposal {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(4)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(5)] public List<PR_ProductCommodity> ProductCommodity { get; set; } = new();
	[SectionPosition(6)] public ID4_LoadDetails? LoadDetails { get; set; }
	[SectionPosition(7)] public IV1_LaneEstimates? LaneEstimates { get; set; }
	[SectionPosition(8)] public MI1_MileageSource? MileageSource { get; set; }
	[SectionPosition(9)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(10)] public List<MCT_TariffAccessorialCharges> TariffAccessorialCharges { get; set; } = new();
	[SectionPosition(11)] public List<L0050> L0050 {get;set;} = new();
	[SectionPosition(12)] public List<L0100> L0100 {get;set;} = new();

	//Details
	[SectionPosition(13)] public List<L0200> L0200 {get;set;} = new();
	[SectionPosition(14)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi107_RequestForMotorCarrierRateProposal>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.DateTime, 0, 10);
		validator.CollectionSize(x => x.BillOfLadingHandlingRequirements, 0, 99);
		validator.CollectionSize(x => x.ProductCommodity, 0, 99);
		validator.CollectionSize(x => x.TariffAccessorialCharges, 0, 999);
		

		validator.CollectionSize(x => x.L0100, 1, 10);
		foreach (var item in L0050) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0200, 1, 99999);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
