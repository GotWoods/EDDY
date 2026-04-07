using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._872;

public class LNM1__LLRQ__LNX1__LPAS_LREF {
	[SectionPosition(1)] public REF_ReferenceIdentification ReferenceIdentification { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1__LLRQ__LNX1__LPAS_LREF>(this);
		validator.Required(x => x.ReferenceIdentification);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 2147483647);
		return validator.Results;
	}
}
