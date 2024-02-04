using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Transportation.v6040._129;

public class LRT {
	[SectionPosition(1)] public RT_RateDestination RateDestination { get; set; } = new();
	[SectionPosition(2)] public List<RT1_RateDetail> RateDetail { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LRT>(this);
		validator.Required(x => x.RateDestination);
		validator.CollectionSize(x => x.RateDetail, 1, 99);
		return validator.Results;
	}
}
