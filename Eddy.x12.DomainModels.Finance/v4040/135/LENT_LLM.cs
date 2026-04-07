using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._135;

public class LENT_LLM {
	[SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; } = new();
	[SectionPosition(2)] public List<LQ_IndustryCode> IndustryCode { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT_LLM>(this);
		validator.Required(x => x.CodeSourceInformation);
		validator.CollectionSize(x => x.IndustryCode, 0, 10);
		return validator.Results;
	}
}
