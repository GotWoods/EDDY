using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._133;

public class LHL_LYNQ {
	[SectionPosition(1)] public YNQ_YesNoQuestion YesNoQuestion { get; set; } = new();
	[SectionPosition(2)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(3)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LYNQ>(this);
		validator.Required(x => x.YesNoQuestion);
		validator.CollectionSize(x => x.Quantity, 1, 2147483647);
		validator.CollectionSize(x => x.PercentAmounts, 1, 2147483647);
		return validator.Results;
	}
}
