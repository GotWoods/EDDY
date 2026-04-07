using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Finance.v7030._820;

public class L6000_L6100 {
	[SectionPosition(1)] public AMT_MonetaryAmountInformation MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L6000_L6100>(this);
		validator.Required(x => x.MonetaryAmountInformation);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		return validator.Results;
	}
}
