using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._602;

public class L0300__L0320__L0321_L0322 {
	[SectionPosition(1)] public SRM_ScaleRates ScaleRates { get; set; } = new();
	[SectionPosition(2)] public List<SRA_TrafficEvaluationFactors> TrafficEvaluationFactors { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300__L0320__L0321_L0322>(this);
		validator.Required(x => x.ScaleRates);
		validator.CollectionSize(x => x.TrafficEvaluationFactors, 0, 5);
		return validator.Results;
	}
}
