using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._811;

public class LHL__LIII_LLQ {
	[SectionPosition(1)] public LQ_IndustryCodeIdentification IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(3)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LIII_LLQ>(this);
		validator.Required(x => x.IndustryCodeIdentification);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 5);
		validator.CollectionSize(x => x.PercentAmounts, 0, 5);
		return validator.Results;
	}
}
