using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._820;

public class LENT__LRMR_LIT1 {
	[SectionPosition(1)] public IT1_BaselineItemDataInvoice BaselineItemDataInvoice { get; set; } = new();
	[SectionPosition(2)] public List<LENT__LRMR__LIT1_LREF> LREF {get;set;} = new();
	[SectionPosition(3)] public List<LENT__LRMR__LIT1_LITA> LITA {get;set;} = new();
	[SectionPosition(4)] public List<LENT__LRMR__LIT1_LSLN> LSLN {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT__LRMR_LIT1>(this);
		validator.Required(x => x.BaselineItemDataInvoice);
		validator.CollectionSize(x => x.LREF, 1, 2147483647);
		validator.CollectionSize(x => x.LITA, 1, 2147483647);
		validator.CollectionSize(x => x.LSLN, 1, 2147483647);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LITA) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSLN) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
