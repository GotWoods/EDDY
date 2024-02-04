using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Transportation.v7050._355;

public class LP4__LLX_LM15 {
	[SectionPosition(1)] public M15_CustomsEventsAdvisoryDetails CustomsEventsAdvisoryDetails { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LM15>(this);
		validator.Required(x => x.CustomsEventsAdvisoryDetails);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
