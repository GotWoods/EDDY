using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._218;

public class L2400__L2410_L2420 {
	[SectionPosition(1)] public SCL_RateBasisScales RateBasisScales { get; set; } = new();
	[SectionPosition(2)] public List<TFR_TariffRestrictions> TariffRestrictions { get; set; } = new();
	[SectionPosition(3)] public List<TFM_TariffMinimumRates> TariffMinimumRates { get; set; } = new();
	[SectionPosition(4)] public List<L2400__L2410__L2420_L2430> L2430 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2400__L2410_L2420>(this);
		validator.Required(x => x.RateBasisScales);
		validator.CollectionSize(x => x.TariffRestrictions, 0, 10);
		validator.CollectionSize(x => x.TariffMinimumRates, 0, 10);
		validator.CollectionSize(x => x.L2430, 0, 999);
		foreach (var item in L2430) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
