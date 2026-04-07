using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._176;

public class LCDS_LBBC {
	[SectionPosition(1)] public BBC_LegalClaims LegalClaims { get; set; } = new();
	[SectionPosition(2)] public AMT_MonetaryAmount? MonetaryAmount { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCDS_LBBC>(this);
		validator.Required(x => x.LegalClaims);
		return validator.Results;
	}
}
