using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Finance.v6040._201;

public class LLRQ__LIN1_LAIN {
	[SectionPosition(1)] public AIN_Income Income { get; set; } = new();
	[SectionPosition(2)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLRQ__LIN1_LAIN>(this);
		validator.Required(x => x.Income);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		return validator.Results;
	}
}
