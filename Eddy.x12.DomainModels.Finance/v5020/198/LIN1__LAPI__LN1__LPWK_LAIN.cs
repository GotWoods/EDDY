using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Finance.v5020._198;

public class LIN1__LAPI__LN1__LPWK_LAIN {
	[SectionPosition(1)] public AIN_Income Income { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1__LAPI__LN1__LPWK_LAIN>(this);
		validator.Required(x => x.Income);
		return validator.Results;
	}
}
