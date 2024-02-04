using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Transportation.v7050._286;

public class LSPI__LHL_LLM {
	[SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; } = new();
	[SectionPosition(2)] public List<LSPI__LHL__LLM_LLQ> LLQ {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSPI__LHL_LLM>(this);
		validator.Required(x => x.CodeSourceInformation);
		validator.CollectionSize(x => x.LLQ, 1, 2147483647);
		foreach (var item in LLQ) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
