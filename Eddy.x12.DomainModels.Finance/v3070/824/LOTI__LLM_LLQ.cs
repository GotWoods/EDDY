using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._824;

public class LOTI__LLM_LLQ {
	[SectionPosition(1)] public LQ_IndustryCode IndustryCode { get; set; } = new();
	[SectionPosition(2)] public List<RED_RelatedData> RelatedData { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LOTI__LLM_LLQ>(this);
		validator.Required(x => x.IndustryCode);
		validator.CollectionSize(x => x.RelatedData, 0, 100);
		return validator.Results;
	}
}
