using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._218;

public class L2300__L2310_L2320 {
	[SectionPosition(1)] public SCL_RateBasisScales RateBasisScales { get; set; } = new();
	[SectionPosition(2)] public RTS_TariffRates? TariffRates { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2300__L2310_L2320>(this);
		validator.Required(x => x.RateBasisScales);
		return validator.Results;
	}
}
