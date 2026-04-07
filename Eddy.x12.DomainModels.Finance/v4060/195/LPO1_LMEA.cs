using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Finance.v4060._195;

public class LPO1_LMEA {
	[SectionPosition(1)] public MEA_Measurements Measurements { get; set; } = new();
	[SectionPosition(2)] public List<LIE_IndividualOrEventLocation> IndividualOrEventLocation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPO1_LMEA>(this);
		validator.Required(x => x.Measurements);
		validator.CollectionSize(x => x.IndividualOrEventLocation, 1, 2147483647);
		return validator.Results;
	}
}
