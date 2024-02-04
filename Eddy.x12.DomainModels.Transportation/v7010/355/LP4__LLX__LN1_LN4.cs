using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Transportation.v7010._355;

public class LP4__LLX__LN1_LN4 {
	[SectionPosition(1)] public N4_GeographicLocation GeographicLocation { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX__LN1_LN4>(this);
		validator.Required(x => x.GeographicLocation);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
