using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Transportation.v8010._470;

public class LLET_LMEA {
	[SectionPosition(1)] public MEA_Measurements Measurements { get; set; } = new();
	[SectionPosition(2)] public List<L4_Measurement> Measurement { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLET_LMEA>(this);
		validator.Required(x => x.Measurements);
		validator.CollectionSize(x => x.Measurement, 0, 99);
		return validator.Results;
	}
}
