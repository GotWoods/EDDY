using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._150;

public class LTFS__LFGS_LTRS {
	[SectionPosition(1)] public TRS_TaxRate TaxRate { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(3)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(4)] public List<LTFS__LFGS__LTRS_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTFS__LFGS_LTRS>(this);
		validator.Required(x => x.TaxRate);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 10);
		validator.CollectionSize(x => x.QuantityInformation, 0, 10);
		validator.CollectionSize(x => x.LN1, 0, 1000);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
