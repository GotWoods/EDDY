using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._176;

public class LFGS_LBBC {
	[SectionPosition(1)] public BBC_LegalClaims LegalClaims { get; set; } = new();
	[SectionPosition(2)] public AMT_MonetaryAmountInformation? MonetaryAmountInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LFGS_LBBC>(this);
		validator.Required(x => x.LegalClaims);
		return validator.Results;
	}
}
