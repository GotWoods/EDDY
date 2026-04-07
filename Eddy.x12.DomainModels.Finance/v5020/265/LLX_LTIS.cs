using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Finance.v5020._265;

public class LLX_LTIS {
	[SectionPosition(1)] public TIS_TitleInsuranceServices TitleInsuranceServices { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LTIS>(this);
		validator.Required(x => x.TitleInsuranceServices);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 30);
		return validator.Results;
	}
}
