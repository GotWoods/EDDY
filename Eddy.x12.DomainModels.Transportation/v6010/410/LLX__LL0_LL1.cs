using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Transportation.v6010._410;

public class LLX__LL0_LL1 {
	[SectionPosition(1)] public L1_RateAndCharges RateAndCharges { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LL0_LL1>(this);
		validator.Required(x => x.RateAndCharges);
		validator.CollectionSize(x => x.DateTimeReference, 0, 4);
		return validator.Results;
	}
}
