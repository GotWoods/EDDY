using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._194;

public class LHL__LPPL_LPD {
	[SectionPosition(1)] public PD_PricingData PricingData { get; set; } = new();
	[SectionPosition(2)] public List<PDD_PricingDataDetail> PricingDataDetail { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LPPL_LPD>(this);
		validator.Required(x => x.PricingData);
		validator.CollectionSize(x => x.PricingDataDetail, 1, 2147483647);
		return validator.Results;
	}
}
