using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._103;

public class LN1__LLX_LSHI {
	[SectionPosition(1)] public SHI_SecurityHoldingInformation SecurityHoldingInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(4)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(5)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1__LLX_LSHI>(this);
		validator.Required(x => x.SecurityHoldingInformation);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.PercentAmounts, 1, 2147483647);
		return validator.Results;
	}
}
