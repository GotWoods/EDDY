using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._200;

public class LRO {
	[SectionPosition(1)] public RO_PublicRecordOrObligation PublicRecordOrObligation { get; set; } = new();
	[SectionPosition(2)] public CDS_CaseDescription? CaseDescription { get; set; }
	[SectionPosition(3)] public List<TBI_TradeLineBureauIdentifier> TradeLineBureauIdentifier { get; set; } = new();
	[SectionPosition(4)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(5)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(6)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(7)] public List<LRO_LAMT> LAMT {get;set;} = new();
	[SectionPosition(8)] public List<LRO_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LRO>(this);
		validator.Required(x => x.PublicRecordOrObligation);
		validator.CollectionSize(x => x.TradeLineBureauIdentifier, 0, 5);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 20);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 10);
		validator.CollectionSize(x => x.LAMT, 0, 6);
		validator.CollectionSize(x => x.LN1, 1, 5);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
