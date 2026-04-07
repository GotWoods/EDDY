using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._195;

public class LPO1__LCRC_LLM {
	[SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; } = new();
	[SectionPosition(2)] public List<LQ_IndustryCode> IndustryCode { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPO1__LCRC_LLM>(this);
		validator.Required(x => x.CodeSourceInformation);
		validator.CollectionSize(x => x.IndustryCode, 1, 2147483647);
		return validator.Results;
	}
}
