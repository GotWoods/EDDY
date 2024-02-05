using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Transportation.v4030._218;

public class L2000 {
	[SectionPosition(1)] public TS_TariffSection TariffSection { get; set; } = new();
	[SectionPosition(2)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(3)] public CL_Class? Class { get; set; }
	[SectionPosition(4)] public WGP_TariffWeightGroup? TariffWeightGroup { get; set; }
	[SectionPosition(5)] public List<TFR_TariffRestrictions> TariffRestrictions { get; set; } = new();
	[SectionPosition(6)] public List<TFM_TariffMinimumRates> TariffMinimumRates { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000>(this);
		validator.Required(x => x.TariffSection);
		validator.CollectionSize(x => x.DateTime, 0, 5);
		validator.CollectionSize(x => x.TariffRestrictions, 0, 10);
		validator.CollectionSize(x => x.TariffMinimumRates, 0, 10);
		return validator.Results;
	}
}
