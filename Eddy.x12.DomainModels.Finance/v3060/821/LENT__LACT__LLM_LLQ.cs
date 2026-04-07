using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._821;

public class LENT__LACT__LLM_LLQ {
	[SectionPosition(1)] public LQ_IndustryCode IndustryCode { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT__LACT__LLM_LLQ>(this);
		validator.Required(x => x.IndustryCode);
		validator.CollectionSize(x => x.DateTimeReference, 0, 3);
		return validator.Results;
	}
}
