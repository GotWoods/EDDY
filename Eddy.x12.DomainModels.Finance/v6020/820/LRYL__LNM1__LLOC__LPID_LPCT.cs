using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._820;

public class LRYL__LNM1__LLOC__LPID_LPCT {
	[SectionPosition(1)] public PCT_PercentAmounts PercentAmounts { get; set; } = new();
	[SectionPosition(2)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(3)] public List<LRYL__LNM1__LLOC__LPID__LPCT_LAMT> LAMT {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LRYL__LNM1__LLOC__LPID_LPCT>(this);
		validator.Required(x => x.PercentAmounts);
		validator.CollectionSize(x => x.LAMT, 1, 2147483647);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
