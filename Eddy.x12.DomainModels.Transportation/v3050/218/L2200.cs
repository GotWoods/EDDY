using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._218;

public class L2200 {
	[SectionPosition(1)] public SCL_RateBasisScales RateBasisScales { get; set; } = new();
	[SectionPosition(2)] public List<TFM_TariffMinimumRates> TariffMinimumRates { get; set; } = new();
	[SectionPosition(3)] public List<L2200_L2210> L2210 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2200>(this);
		validator.Required(x => x.RateBasisScales);
		validator.CollectionSize(x => x.TariffMinimumRates, 0, 10);
		validator.CollectionSize(x => x.L2210, 0, 25);
		foreach (var item in L2210) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
