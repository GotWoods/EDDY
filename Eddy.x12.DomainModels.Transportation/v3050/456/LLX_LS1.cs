using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._456;

public class LLX_LS1 {
	[SectionPosition(1)] public S1_StopOffName StopOffName { get; set; } = new();
	[SectionPosition(2)] public List<S9_StopOffStation> StopOffStation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LS1>(this);
		validator.Required(x => x.StopOffName);
		validator.CollectionSize(x => x.StopOffStation, 0, 3);
		return validator.Results;
	}
}
