using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._814;

public class LLIN__LFA1_LAMT {
	[SectionPosition(1)] public AMT_MonetaryAmountInformation MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(2)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLIN__LFA1_LAMT>(this);
		validator.Required(x => x.MonetaryAmountInformation);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 2147483647);
		return validator.Results;
	}
}
