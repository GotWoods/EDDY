using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Finance.v5050._260;

public class L0200_L0210 {
	[SectionPosition(1)] public DFI_DefaultInformation DefaultInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(3)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0210>(this);
		validator.Required(x => x.DefaultInformation);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 19);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 4);
		return validator.Results;
	}
}
