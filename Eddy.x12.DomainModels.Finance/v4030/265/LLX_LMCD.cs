using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._265;

public class LLX_LMCD {
	[SectionPosition(1)] public MCD_MortgageClosingData MortgageClosingData { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LMCD>(this);
		validator.Required(x => x.MortgageClosingData);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 50);
		return validator.Results;
	}
}
