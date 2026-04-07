using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._820;

public class L7000__L7100_L7120 {
	[SectionPosition(1)] public ASM_AmountAndSettlementMethod AmountAndSettlementMethod { get; set; } = new();
	[SectionPosition(2)] public ADX_Adjustment? Adjustment { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L7000__L7100_L7120>(this);
		validator.Required(x => x.AmountAndSettlementMethod);
		return validator.Results;
	}
}
