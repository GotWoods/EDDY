using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._218;

public class L2100 {
	[SectionPosition(1)] public SCL_RateBasisScales RateBasisScales { get; set; } = new();
	[SectionPosition(2)] public List<TFM_TariffMinimumRates> TariffMinimumRates { get; set; } = new();
	[SectionPosition(3)] public RTS_TariffRates? TariffRates { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2100>(this);
		validator.Required(x => x.RateBasisScales);
		validator.CollectionSize(x => x.TariffMinimumRates, 0, 10);
		return validator.Results;
	}
}
