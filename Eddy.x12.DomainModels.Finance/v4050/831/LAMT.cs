using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._831;

public class LAMT {
	[SectionPosition(1)] public AMT_MonetaryAmount MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(2)] public QTY_Quantity? QuantityInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LAMT>(this);
		validator.Required(x => x.MonetaryAmountInformation);
		return validator.Results;
	}
}
