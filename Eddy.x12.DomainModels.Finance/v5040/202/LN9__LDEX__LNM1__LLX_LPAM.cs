using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._202;

public class LN9__LDEX__LNM1__LLX_LPAM {
	[SectionPosition(1)] public PAM_PeriodAmount PeriodAmount { get; set; } = new();
	[SectionPosition(2)] public YNQ_YesNoQuestion YesNoQuestion { get; set; } = new();
	[SectionPosition(3)] public REF_ReferenceInformation ReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9__LDEX__LNM1__LLX_LPAM>(this);
		validator.Required(x => x.PeriodAmount);
		validator.Required(x => x.YesNoQuestion);
		validator.Required(x => x.ReferenceInformation);
		return validator.Results;
	}
}
