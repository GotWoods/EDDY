using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Finance.v3040._822;

public class LN1__LACT_LRTE {
	[SectionPosition(1)] public RTE_RateInformation RateInformation { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1__LACT_LRTE>(this);
		validator.Required(x => x.RateInformation);
		return validator.Results;
	}
}
