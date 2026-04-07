using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Finance.v7040._811;

public class LN1__LLX_LITA {
	[SectionPosition(1)] public ITA_AllowanceChargeOrService AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1__LLX_LITA>(this);
		validator.Required(x => x.AllowanceChargeOrService);
		return validator.Results;
	}
}
