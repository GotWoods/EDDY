using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._265;

public class LLX_LTIS {
	[SectionPosition(1)] public TIS_TitleInsuranceServices TitleInsuranceServices { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LTIS>(this);
		validator.Required(x => x.TitleInsuranceServices);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 30);
		return validator.Results;
	}
}
