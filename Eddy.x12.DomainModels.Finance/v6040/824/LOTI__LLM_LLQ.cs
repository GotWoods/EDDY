using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Finance.v6040._824;

public class LOTI__LLM_LLQ {
	[SectionPosition(1)] public LQ_IndustryCodeIdentification IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(2)] public List<RED_RelatedData> RelatedData { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LOTI__LLM_LLQ>(this);
		validator.Required(x => x.IndustryCodeIdentification);
		validator.CollectionSize(x => x.RelatedData, 0, 100);
		return validator.Results;
	}
}
