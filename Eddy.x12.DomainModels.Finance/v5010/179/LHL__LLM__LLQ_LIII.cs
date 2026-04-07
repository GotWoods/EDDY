using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Finance.v5010._179;

public class LHL__LLM__LLQ_LIII {
	[SectionPosition(1)] public III_Information Information { get; set; } = new();
	[SectionPosition(2)] public LOC_Location? Location { get; set; }
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LLM__LLQ_LIII>(this);
		validator.Required(x => x.Information);
		validator.CollectionSize(x => x.Measurements, 1, 2147483647);
		return validator.Results;
	}
}
