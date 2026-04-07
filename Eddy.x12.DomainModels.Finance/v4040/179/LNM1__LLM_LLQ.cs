using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._179;

public class LNM1__LLM_LLQ {
	[SectionPosition(1)] public LQ_IndustryCode IndustryCode { get; set; } = new();
	[SectionPosition(2)] public LOC_Location? Location { get; set; }
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1__LLM_LLQ>(this);
		validator.Required(x => x.IndustryCode);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		return validator.Results;
	}
}
