using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._195;

public class LPO1_LLM {
	[SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; } = new();
	[SectionPosition(2)] public List<LQ_IndustryCode> IndustryCode { get; set; } = new();
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(4)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPO1_LLM>(this);
		validator.Required(x => x.CodeSourceInformation);
		validator.CollectionSize(x => x.IndustryCode, 1, 2147483647);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		return validator.Results;
	}
}
