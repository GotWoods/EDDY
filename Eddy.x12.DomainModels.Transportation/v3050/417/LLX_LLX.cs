using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._417;

public class LLX_LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<L0_LineItemQuantityAndWeight> LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(4)] public List<L1_RateAndCharges> RateAndCharges { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.LineItemQuantityAndWeight, 0, 10);
		validator.CollectionSize(x => x.Measurements, 0, 3);
		validator.CollectionSize(x => x.RateAndCharges, 0, 10);
		return validator.Results;
	}
}
