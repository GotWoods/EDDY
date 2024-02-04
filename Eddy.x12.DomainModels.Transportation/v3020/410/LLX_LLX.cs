using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._410;

public class LLX_LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<L0_LineItemQuantityAndWeight> LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(3)] public List<L1_RateAndCharges> RateAndCharges { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.LineItemQuantityAndWeight, 1, 10);
		validator.CollectionSize(x => x.RateAndCharges, 1, 10);
		return validator.Results;
	}
}
