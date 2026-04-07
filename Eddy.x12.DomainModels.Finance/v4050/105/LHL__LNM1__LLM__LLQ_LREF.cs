using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._105;

public class LHL__LNM1__LLM__LLQ_LREF {
	[SectionPosition(1)] public REF_ReferenceIdentification ReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public AMT_MonetaryAmount? MonetaryAmountInformation { get; set; }
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public CUR_Currency? Currency { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LNM1__LLM__LLQ_LREF>(this);
		validator.Required(x => x.ReferenceInformation);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		return validator.Results;
	}
}
