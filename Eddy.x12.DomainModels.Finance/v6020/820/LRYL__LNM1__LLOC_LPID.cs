using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._820;

public class LRYL__LNM1__LLOC_LPID {
	[SectionPosition(1)] public PID_ProductItemDescription ProductItemDescription { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(3)] public List<LRYL__LNM1__LLOC__LPID_LPCT> LPCT {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LRYL__LNM1__LLOC_LPID>(this);
		validator.Required(x => x.ProductItemDescription);
		validator.CollectionSize(x => x.LPCT, 1, 2147483647);
		foreach (var item in LPCT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
