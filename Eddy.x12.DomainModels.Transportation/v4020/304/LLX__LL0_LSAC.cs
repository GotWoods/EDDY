using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._304;

public class LLX__LL0_LSAC {
	[SectionPosition(1)] public SAC_ServicePromotionAllowanceOrChargeInformation ServicePromotionAllowanceOrChargeInformation { get; set; } = new();
	[SectionPosition(2)] public CUR_Currency? Currency { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LL0_LSAC>(this);
		validator.Required(x => x.ServicePromotionAllowanceOrChargeInformation);
		return validator.Results;
	}
}
