using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._283;

public class LTXI__LLX__LN1_LPID {
	[SectionPosition(1)] public PID_ProductItemDescription ProductItemDescription { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(3)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTXI__LLX__LN1_LPID>(this);
		validator.Required(x => x.ProductItemDescription);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		return validator.Results;
	}
}
