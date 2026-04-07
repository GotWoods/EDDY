using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._288;

public class LDTM {
	[SectionPosition(1)] public DTM_DateTimeReference DateTimeReference { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<AMT_MonetaryAmount> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(4)] public List<QTY_Quantity> QuantityInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDTM>(this);
		validator.Required(x => x.DateTimeReference);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 1, 2147483647);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		return validator.Results;
	}
}
