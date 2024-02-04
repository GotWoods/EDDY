using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Transportation.v5050._463;

public class LDK {
	[SectionPosition(1)] public DK_DocketHeader DocketHeader { get; set; } = new();
	[SectionPosition(2)] public List<LDK_LLQ> LLQ {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDK>(this);
		validator.Required(x => x.DocketHeader);
		validator.CollectionSize(x => x.LLQ, 0, 10);
		foreach (var item in LLQ) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
