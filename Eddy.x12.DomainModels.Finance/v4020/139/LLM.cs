using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._139;

public class LLM {
	[SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; } = new();
	[SectionPosition(2)] public List<LQ_IndustryCode> IndustryCode { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLM>(this);
		validator.Required(x => x.CodeSourceInformation);
		validator.CollectionSize(x => x.IndustryCode, 1, 10);
		return validator.Results;
	}
}
