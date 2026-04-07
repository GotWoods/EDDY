using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._245;

public class LHL__LTDT_LREF {
	[SectionPosition(1)] public REF_ReferenceIdentification ReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LTDT_LREF>(this);
		validator.Required(x => x.ReferenceInformation);
		return validator.Results;
	}
}
