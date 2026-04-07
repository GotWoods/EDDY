using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._185;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public ASI_ActionOrStatusIndicator? ActionOrStatusIndicator { get; set; }
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(5)] public List<N1_Name> Name { get; set; } = new();
	[SectionPosition(6)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(7)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(8)] public List<ASM_AmountAndSettlementMethod> AmountAndSettlementMethod { get; set; } = new();
	[SectionPosition(9)] public List<LLX_LLM> LLM {get;set;} = new();
	[SectionPosition(10)] public List<LLX_LPID> LPID {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.Name, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.PercentAmounts, 1, 2147483647);
		validator.CollectionSize(x => x.AmountAndSettlementMethod, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		validator.CollectionSize(x => x.LPID, 1, 2147483647);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPID) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
