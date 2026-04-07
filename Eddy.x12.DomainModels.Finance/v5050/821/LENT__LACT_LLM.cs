using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Finance.v5050._821;

public class LENT__LACT_LLM {
	[SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; } = new();
	[SectionPosition(2)] public List<LENT__LACT__LLM_LLQ> LLQ {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT__LACT_LLM>(this);
		validator.Required(x => x.CodeSourceInformation);
		validator.CollectionSize(x => x.LLQ, 1, 100);
		foreach (var item in LLQ) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
