using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._284;

public class LHL__LLQ_LAMT {
	[SectionPosition(1)] public AMT_MonetaryAmountInformation MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LLQ_LAMT>(this);
		validator.Required(x => x.MonetaryAmountInformation);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		return validator.Results;
	}
}
