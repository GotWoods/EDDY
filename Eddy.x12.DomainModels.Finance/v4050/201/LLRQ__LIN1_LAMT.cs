using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._201;

public class LLRQ__LIN1_LAMT {
	[SectionPosition(1)] public AMT_MonetaryAmount MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(2)] public MSG_MessageText? MessageText { get; set; }
	[SectionPosition(3)] public QTY_Quantity? QuantityInformation { get; set; }
	[SectionPosition(4)] public YNQ_YesNoQuestion? YesNoQuestion { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLRQ__LIN1_LAMT>(this);
		validator.Required(x => x.MonetaryAmountInformation);
		return validator.Results;
	}
}
