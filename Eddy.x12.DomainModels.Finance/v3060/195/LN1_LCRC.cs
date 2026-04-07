using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._195;

public class LN1_LCRC {
	[SectionPosition(1)] public CRC_ConditionsIndicator ConditionsIndicator { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1_LCRC>(this);
		validator.Required(x => x.ConditionsIndicator);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		return validator.Results;
	}
}
