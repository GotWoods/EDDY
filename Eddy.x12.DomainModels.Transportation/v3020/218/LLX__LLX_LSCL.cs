using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._218;

public class LLX__LLX_LSCL {
	[SectionPosition(1)] public SCL_RateBasisScales RateBasisScales { get; set; } = new();
	[SectionPosition(2)] public List<TFR_TariffRestrictions> TariffRestrictions { get; set; } = new();
	[SectionPosition(3)] public List<TFM_TariffMinimumRates> TariffMinimumRates { get; set; } = new();
	[SectionPosition(4)] public List<LLX__LLX__LSCL_LCL> LCL {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LLX_LSCL>(this);
		validator.Required(x => x.RateBasisScales);
		validator.CollectionSize(x => x.TariffRestrictions, 0, 10);
		validator.CollectionSize(x => x.TariffMinimumRates, 0, 10);
		validator.CollectionSize(x => x.LCL, 0, 999);
		foreach (var item in LCL) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
