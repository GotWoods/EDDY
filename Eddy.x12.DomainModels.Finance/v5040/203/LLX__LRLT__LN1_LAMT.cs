using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._203;

public class LLX__LRLT__LN1_LAMT {
	[SectionPosition(1)] public AMT_MonetaryAmountInformation MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LRLT__LN1_LAMT>(this);
		validator.Required(x => x.MonetaryAmountInformation);
		return validator.Results;
	}
}
