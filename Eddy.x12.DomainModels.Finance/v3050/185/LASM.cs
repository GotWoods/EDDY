using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._185;

public class LASM {
	[SectionPosition(1)] public ASM_AmountAndSettlementMethod AmountAndSettlementMethod { get; set; } = new();
	[SectionPosition(2)] public REF_ReferenceNumbers? ReferenceNumbers { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LASM>(this);
		validator.Required(x => x.AmountAndSettlementMethod);
		return validator.Results;
	}
}
