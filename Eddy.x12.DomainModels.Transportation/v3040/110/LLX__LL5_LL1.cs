using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Transportation.v3040._110;

public class LLX__LL5_LL1 {
	[SectionPosition(1)] public L1_RateAndCharges RateAndCharges { get; set; } = new();
	[SectionPosition(2)] public C3_Currency? Currency { get; set; }
	[SectionPosition(3)] public L4_Measurement? Measurement { get; set; }
	[SectionPosition(4)] public List<L10_Weight> Weight { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LL5_LL1>(this);
		validator.Required(x => x.RateAndCharges);
		validator.CollectionSize(x => x.Weight, 0, 4);
		return validator.Results;
	}
}
