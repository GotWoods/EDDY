using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Finance.v5050._820;

public class LINS_LADX {
	[SectionPosition(1)] public ADX_Adjustment Adjustment { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LINS_LADX>(this);
		validator.Required(x => x.Adjustment);
		return validator.Results;
	}
}
