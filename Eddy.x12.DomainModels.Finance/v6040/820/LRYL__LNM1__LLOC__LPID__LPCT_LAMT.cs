using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Finance.v6040._820;

public class LRYL__LNM1__LLOC__LPID__LPCT_LAMT {
	[SectionPosition(1)] public AMT_MonetaryAmountInformation MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(2)] public List<ADX_Adjustment> Adjustment { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LRYL__LNM1__LLOC__LPID__LPCT_LAMT>(this);
		validator.Required(x => x.MonetaryAmountInformation);
		validator.CollectionSize(x => x.Adjustment, 1, 2147483647);
		return validator.Results;
	}
}
