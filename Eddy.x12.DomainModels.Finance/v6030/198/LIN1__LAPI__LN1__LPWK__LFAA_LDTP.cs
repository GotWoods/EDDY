using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._198;

public class LIN1__LAPI__LN1__LPWK__LFAA_LDTP {
	[SectionPosition(1)] public DTP_DateOrTimeOrPeriod DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(2)] public AMT_MonetaryAmountInformation? MonetaryAmountInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1__LAPI__LN1__LPWK__LFAA_LDTP>(this);
		validator.Required(x => x.DateOrTimeOrPeriod);
		return validator.Results;
	}
}
