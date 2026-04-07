using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._176;

public class LFGS__LNM1_LBBC {
	[SectionPosition(1)] public BBC_LegalClaims LegalClaims { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LFGS__LNM1_LBBC>(this);
		validator.Required(x => x.LegalClaims);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		return validator.Results;
	}
}
