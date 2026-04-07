using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Finance.v7060._201;

public class LLRQ_LPEX {
	[SectionPosition(1)] public PEX_PropertyOrHousingExpense PropertyOrHousingExpense { get; set; } = new();
	[SectionPosition(2)] public MSG_MessageText? MessageText { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLRQ_LPEX>(this);
		validator.Required(x => x.PropertyOrHousingExpense);
		return validator.Results;
	}
}
