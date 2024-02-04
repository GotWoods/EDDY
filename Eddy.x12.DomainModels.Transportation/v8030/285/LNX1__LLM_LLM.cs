using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Transportation.v8030._285;

public class LNX1__LLM_LLM {
	[SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; } = new();
	[SectionPosition(2)] public LQ_IndustryCodeIdentification IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(3)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(4)] public REF_ReferenceInformation? ReferenceInformation { get; set; }
	[SectionPosition(5)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(6)] public PCT_PercentAmounts? PercentAmounts { get; set; }
	[SectionPosition(7)] public AMT_MonetaryAmountInformation? MonetaryAmountInformation { get; set; }
	[SectionPosition(8)] public SPR_SupplierRating? SupplierRating { get; set; }
	[SectionPosition(9)] public SRE_TestScores? TestScores { get; set; }
	[SectionPosition(10)] public List<STA_Statistics> Statistics { get; set; } = new();
	[SectionPosition(11)] public MEA_Measurements? Measurements { get; set; }
	[SectionPosition(12)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(13)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(14)] public List<LNX1__LLM__LLM_LTC2> LTC2 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNX1__LLM_LLM>(this);
		validator.Required(x => x.CodeSourceInformation);
		validator.Required(x => x.IndustryCodeIdentification);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.Statistics, 1, 2147483647);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.LTC2, 1, 2147483647);
		foreach (var item in LTC2) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
