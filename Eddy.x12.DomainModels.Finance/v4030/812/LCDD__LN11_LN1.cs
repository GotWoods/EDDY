using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._812;

public class LCDD__LN11_LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(3)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCDD__LN11_LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 10);
		validator.CollectionSize(x => x.PercentAmounts, 0, 2);
		return validator.Results;
	}
}
