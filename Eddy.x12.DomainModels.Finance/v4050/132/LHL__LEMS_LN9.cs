using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._132;

public class LHL__LEMS_LN9 {
	[SectionPosition(1)] public N9_ReferenceIdentification ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public PCT_PercentAmounts? PercentAmounts { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LEMS_LN9>(this);
		validator.Required(x => x.ExtendedReferenceInformation);
		return validator.Results;
	}
}
