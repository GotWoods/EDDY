using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._105;

public class LAMT {
	[SectionPosition(1)] public AMT_MonetaryAmount MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(2)] public PDL_PaymentDetails? PaymentDetails { get; set; }
	[SectionPosition(3)] public List<REF_ReferenceIdentification> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(5)] public CUR_Currency? Currency { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LAMT>(this);
		validator.Required(x => x.MonetaryAmountInformation);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		return validator.Results;
	}
}
