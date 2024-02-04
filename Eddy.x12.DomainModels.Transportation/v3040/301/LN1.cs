using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Transportation.v3040._301;

public class LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1>(this);
		validator.Required(x => x.Name);
		return validator.Results;
	}
}
