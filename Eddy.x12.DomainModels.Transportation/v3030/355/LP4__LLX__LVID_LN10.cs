using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._355;

public class LP4__LLX__LVID_LN10 {
	[SectionPosition(1)] public N10_QuantityAndDescription QuantityAndDescription { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX__LVID_LN10>(this);
		validator.Required(x => x.QuantityAndDescription);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
