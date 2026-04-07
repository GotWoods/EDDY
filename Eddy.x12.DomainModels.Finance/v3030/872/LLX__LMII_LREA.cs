using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._872;

public class LLX__LMII_LREA {
	[SectionPosition(1)] public REA_RealEstatePropertyInformation RealEstatePropertyInformation { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LMII_LREA>(this);
		validator.Required(x => x.RealEstatePropertyInformation);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 10);
		return validator.Results;
	}
}
