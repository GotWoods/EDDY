using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._811;

public class LHL_LIII {
	[SectionPosition(1)] public III_Information Information { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(3)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(4)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(5)] public List<LHL__LIII_LLQ> LLQ {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LIII>(this);
		validator.Required(x => x.Information);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 5);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 5);
		validator.CollectionSize(x => x.PercentAmounts, 0, 5);
		validator.CollectionSize(x => x.LLQ, 1, 2147483647);
		foreach (var item in LLQ) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
