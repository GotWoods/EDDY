using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Finance.v7030._844;

public class LCON__LN1_LSII {
	[SectionPosition(1)] public SII_SalesItemInformation SalesItemInformation { get; set; } = new();
	[SectionPosition(2)] public N9_ExtendedReferenceInformation? ExtendedReferenceInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCON__LN1_LSII>(this);
		validator.Required(x => x.SalesItemInformation);
		return validator.Results;
	}
}
