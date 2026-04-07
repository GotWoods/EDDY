using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Finance.v6010._820;

public class LRYL__LNM1_LLOC {
	[SectionPosition(1)] public LOC_Location Location { get; set; } = new();
	[SectionPosition(2)] public List<LRYL__LNM1__LLOC_LPID> LPID {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LRYL__LNM1_LLOC>(this);
		validator.Required(x => x.Location);
		validator.CollectionSize(x => x.LPID, 1, 2147483647);
		foreach (var item in LPID) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
