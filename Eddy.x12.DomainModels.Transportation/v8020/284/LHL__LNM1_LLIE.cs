using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Transportation.v8020._284;

public class LHL__LNM1_LLIE {
	[SectionPosition(1)] public LIE_IndividualOrEventLocation IndividualOrEventLocation { get; set; } = new();
	[SectionPosition(2)] public MEA_Measurements? Measurements { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LNM1_LLIE>(this);
		validator.Required(x => x.IndividualOrEventLocation);
		return validator.Results;
	}
}
