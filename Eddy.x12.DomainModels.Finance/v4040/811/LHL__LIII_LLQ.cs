using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._811;

public class LHL__LIII_LLQ {
	[SectionPosition(1)] public LQ_IndustryCode IndustryCode { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(3)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LIII_LLQ>(this);
		validator.Required(x => x.IndustryCode);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 5);
		validator.CollectionSize(x => x.PercentAmounts, 0, 5);
		return validator.Results;
	}
}
