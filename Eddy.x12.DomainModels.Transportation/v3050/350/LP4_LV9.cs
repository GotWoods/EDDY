using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._350;

public class LP4_LV9 {
	[SectionPosition(1)] public V9_EventDetail EventDetail { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LV9>(this);
		validator.Required(x => x.EventDetail);
		validator.CollectionSize(x => x.Remarks, 0, 4);
		return validator.Results;
	}
}
