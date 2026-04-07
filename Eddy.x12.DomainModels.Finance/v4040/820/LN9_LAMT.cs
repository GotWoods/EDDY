using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._820;

public class LN9_LAMT {
	[SectionPosition(1)] public AMT_MonetaryAmount MonetaryAmount { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9_LAMT>(this);
		validator.Required(x => x.MonetaryAmount);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		return validator.Results;
	}
}
