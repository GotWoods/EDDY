using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Transportation.v4060._602;

public class L0300__L0310_L0311 {
	[SectionPosition(1)] public RA_RateHeader RateHeader { get; set; } = new();
	[SectionPosition(2)] public List<RB_RateMinimumDetail> RateMinimumDetail { get; set; } = new();
	[SectionPosition(3)] public List<FK_Factor> Factor { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300__L0310_L0311>(this);
		validator.Required(x => x.RateHeader);
		validator.CollectionSize(x => x.RateMinimumDetail, 0, 8);
		validator.CollectionSize(x => x.Factor, 0, 15);
		return validator.Results;
	}
}
