using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._527;

public class LLIN_LRCD {
	[SectionPosition(1)] public RCD_ReceivingConditions ReceivingConditions { get; set; } = new();
	[SectionPosition(2)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(3)] public GF_FurnishedGoodsAndServices? FurnishedGoodsAndServices { get; set; }
	[SectionPosition(4)] public List<AT_FinancialAccounting> FinancialAccounting { get; set; } = new();
	[SectionPosition(5)] public List<DD_DemandDetail> DemandDetail { get; set; } = new();
	[SectionPosition(6)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(7)] public AMT_MonetaryAmount? MonetaryAmount { get; set; }
	[SectionPosition(8)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(9)] public List<G66_TransportationInstructions> TransportationInstructions { get; set; } = new();
	[SectionPosition(10)] public List<LLIN__LRCD_LLM> LLM {get;set;} = new();
	[SectionPosition(11)] public List<LLIN__LRCD_LCS> LCS {get;set;} = new();
	[SectionPosition(12)] public List<LLIN__LRCD_LN1> LN1 {get;set;} = new();
	[SectionPosition(13)] public List<LLIN__LRCD_LREF> LREF {get;set;} = new();
	[SectionPosition(14)] public List<LLIN__LRCD_LQTY> LQTY {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLIN_LRCD>(this);
		validator.Required(x => x.ReceivingConditions);
		validator.CollectionSize(x => x.DateTime, 0, 10);
		validator.CollectionSize(x => x.FinancialAccounting, 1, 2147483647);
		validator.CollectionSize(x => x.DemandDetail, 0, 100);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 5);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 5);
		validator.CollectionSize(x => x.TransportationInstructions, 0, 5);
		validator.CollectionSize(x => x.LLM, 0, 25);
		validator.CollectionSize(x => x.LCS, 1, 2147483647);
		validator.CollectionSize(x => x.LN1, 0, 25);
		validator.CollectionSize(x => x.LREF, 1, 2147483647);
		validator.CollectionSize(x => x.LQTY, 1, 2147483647);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LCS) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LQTY) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
