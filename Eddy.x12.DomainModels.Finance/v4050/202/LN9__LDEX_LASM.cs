using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._202;

public class LN9__LDEX_LASM {
	[SectionPosition(1)] public ASM_AmountAndSettlementMethod AmountAndSettlementMethod { get; set; } = new();
	[SectionPosition(2)] public N1_Name? PartyIdentification { get; set; }
	[SectionPosition(3)] public List<REF_ReferenceIdentification> ReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9__LDEX_LASM>(this);
		validator.Required(x => x.AmountAndSettlementMethod);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 5);
		return validator.Results;
	}
}
