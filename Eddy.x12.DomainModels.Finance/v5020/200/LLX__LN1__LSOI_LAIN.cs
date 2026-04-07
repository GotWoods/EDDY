using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Finance.v5020._200;

public class LLX__LN1__LSOI_LAIN {
	[SectionPosition(1)] public AIN_Income Income { get; set; } = new();
	[SectionPosition(2)] public YNQ_YesNoQuestion? YesNoQuestion { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LN1__LSOI_LAIN>(this);
		validator.Required(x => x.Income);
		return validator.Results;
	}
}
