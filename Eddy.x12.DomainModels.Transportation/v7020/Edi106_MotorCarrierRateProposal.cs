using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;
using Eddy.x12.DomainModels.Transportation.v7020._106;

namespace Eddy.x12.DomainModels.Transportation.v7020;

public class Edi106_MotorCarrierRateProposal {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public BLR_TransportationCarrierIdentification TransportationCarrierIdentification { get; set; } = new();
	[SectionPosition(4)] public TFR_TariffRestrictions? TariffRestrictions { get; set; }
	[SectionPosition(5)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(6)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(7)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
	[SectionPosition(8)] public List<PR_ProductCommodity> ProductCommodity { get; set; } = new();
	[SectionPosition(9)] public LC1_LaneCommitments? LaneCommitments { get; set; }
	[SectionPosition(10)] public MI1_MileageSource? MileageSource { get; set; }
	[SectionPosition(11)] public List<MCT_TariffAccessorialCharges> TariffAccessorialCharges { get; set; } = new();
	[SectionPosition(12)] public List<L0050> L0050 {get;set;} = new();
	[SectionPosition(13)] public List<L0100> L0100 {get;set;} = new();
	[SectionPosition(14)] public List<L0200> L0200 {get;set;} = new();

	//Details
	[SectionPosition(15)] public List<L0400> L0400 {get;set;} = new();
	[SectionPosition(16)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();

	//Summary


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi106_MotorCarrierRateProposal>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.TransportationCarrierIdentification);
		validator.CollectionSize(x => x.DateTime, 0, 10);
		validator.CollectionSize(x => x.BillOfLadingHandlingRequirements, 0, 99);
		validator.CollectionSize(x => x.ProductCommodity, 0, 99);
		validator.CollectionSize(x => x.TariffAccessorialCharges, 0, 999);
		

		validator.CollectionSize(x => x.L0200, 1, 10);
		foreach (var item in L0050) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0200) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.L0400, 1, 99999);
		foreach (var item in L0400) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
