using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._527;

public class LLIN__LRCD_LLM {
	[SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; } = new();
	[SectionPosition(2)] public List<LQ_IndustryCode> IndustryCodeIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLIN__LRCD_LLM>(this);
		validator.Required(x => x.CodeSourceInformation);
		validator.CollectionSize(x => x.IndustryCodeIdentification, 1, 100);
		return validator.Results;
	}
}
