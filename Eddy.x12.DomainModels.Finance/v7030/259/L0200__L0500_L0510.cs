using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Finance.v7030._259;

public class L0200__L0500_L0510 {
	[SectionPosition(1)] public AWD_AmountWithDescription AmountWithDescription { get; set; } = new();
	[SectionPosition(2)] public AMT_MonetaryAmountInformation? MonetaryAmountInformation { get; set; }
	[SectionPosition(3)] public List<III_Information> Information { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200__L0500_L0510>(this);
		validator.Required(x => x.AmountWithDescription);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		return validator.Results;
	}
}
