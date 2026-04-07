using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Finance.v8030._194;

public class LHL__LPPL_LPL {
	[SectionPosition(1)] public PL_ProposalCostLogic ProposalCostLogic { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public AMT_MonetaryAmountInformation? MonetaryAmountInformation { get; set; }
	[SectionPosition(4)] public PCT_PercentAmounts? PercentAmounts { get; set; }
	[SectionPosition(5)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(6)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(7)] public List<LHL__LPPL__LPL_LPD> LPD {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LPPL_LPL>(this);
		validator.Required(x => x.ProposalCostLogic);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.LPD, 1, 2147483647);
		foreach (var item in LPD) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
