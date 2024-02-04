using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Transportation.v5010._285;

public class LNX1__LLM__LLM__LTC2_LN4 {
	[SectionPosition(1)] public N4_GeographicLocation GeographicLocation { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNX1__LLM__LLM__LTC2_LN4>(this);
		validator.Required(x => x.GeographicLocation);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		return validator.Results;
	}
}
