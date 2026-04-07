using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Finance.v6010._189;

public class LAMT {
	[SectionPosition(1)] public AMT_MonetaryAmountInformation MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(2)] public MSG_MessageText? MessageText { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LAMT>(this);
		validator.Required(x => x.MonetaryAmountInformation);
		return validator.Results;
	}
}
