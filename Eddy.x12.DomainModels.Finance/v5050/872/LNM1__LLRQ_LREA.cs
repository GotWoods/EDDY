using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Finance.v5050._872;

public class LNM1__LLRQ_LREA {
	[SectionPosition(1)] public REA_RealEstatePropertyInformation RealEstatePropertyInformation { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1__LLRQ_LREA>(this);
		validator.Required(x => x.RealEstatePropertyInformation);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 10);
		return validator.Results;
	}
}
