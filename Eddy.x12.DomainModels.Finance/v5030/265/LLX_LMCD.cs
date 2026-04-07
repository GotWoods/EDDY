using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Finance.v5030._265;

public class LLX_LMCD {
	[SectionPosition(1)] public MCD_MortgageClosingData MortgageClosingData { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LMCD>(this);
		validator.Required(x => x.MortgageClosingData);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 50);
		return validator.Results;
	}
}
