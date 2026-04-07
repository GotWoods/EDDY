using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Finance.v6050._820;

public class LENT__LADX_LIT1 {
	[SectionPosition(1)] public IT1_BaselineItemDataInvoice BaselineItemDataInvoice { get; set; } = new();
	[SectionPosition(2)] public RPA_RateAmountsOrPercents? RateAmountsOrPercents { get; set; }
	[SectionPosition(3)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(4)] public List<LENT__LADX__LIT1_LREF> LREF {get;set;} = new();
	[SectionPosition(5)] public List<LENT__LADX__LIT1_LSAC> LSAC {get;set;} = new();
	[SectionPosition(6)] public List<LENT__LADX__LIT1_LSLN> LSLN {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT__LADX_LIT1>(this);
		validator.Required(x => x.BaselineItemDataInvoice);
		validator.CollectionSize(x => x.LREF, 1, 2147483647);
		validator.CollectionSize(x => x.LSAC, 1, 2147483647);
		validator.CollectionSize(x => x.LSLN, 1, 2147483647);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSAC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSLN) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
