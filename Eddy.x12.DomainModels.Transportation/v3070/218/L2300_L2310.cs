using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._218;

public class L2300_L2310 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public SCL_RateBasisScales? RateBasisScales { get; set; }
	[SectionPosition(4)] public List<TFR_TariffRestrictions> TariffRestrictions { get; set; } = new();
	[SectionPosition(5)] public List<TFM_TariffMinimumRates> TariffMinimumRates { get; set; } = new();
	[SectionPosition(6)] public RTS_TariffRates? TariffRates { get; set; }
	[SectionPosition(7)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(8)] public List<L2300__L2310_L2320> L2320 {get;set;} = new();
	[SectionPosition(9)] public LE_LoopTrailer? LoopTrailer { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2300_L2310>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.Geography, 0, 99);
		validator.CollectionSize(x => x.TariffRestrictions, 0, 10);
		validator.CollectionSize(x => x.TariffMinimumRates, 0, 10);
		validator.CollectionSize(x => x.L2320, 0, 9999);
		foreach (var item in L2320) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
