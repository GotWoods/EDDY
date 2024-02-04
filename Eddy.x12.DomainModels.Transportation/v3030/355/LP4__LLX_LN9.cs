using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._355;

public class LP4__LLX_LN9 {
	[SectionPosition(1)] public N9_ReferenceNumber ReferenceNumber { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LN9>(this);
		validator.Required(x => x.ReferenceNumber);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
