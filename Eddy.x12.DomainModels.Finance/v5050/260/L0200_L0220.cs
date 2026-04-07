using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Finance.v5050._260;

public class L0200_L0220 {
	[SectionPosition(1)] public REC_RealEstateCondition RealEstateCondition { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<L0200__L0220_L0221> L0221 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0220>(this);
		validator.Required(x => x.RealEstateCondition);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 6);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 4);
		foreach (var item in L0221) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
