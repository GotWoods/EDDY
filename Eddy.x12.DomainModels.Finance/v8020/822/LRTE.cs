using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._822;

public class LRTE {
	[SectionPosition(1)] public RTE_RateInformation RateInformation { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LRTE>(this);
		validator.Required(x => x.RateInformation);
		return validator.Results;
	}
}
