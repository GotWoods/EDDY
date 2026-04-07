using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._820;

public class L8000_L8100 {
	[SectionPosition(1)] public ADX_Adjustment Adjustment { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L8000_L8100>(this);
		validator.Required(x => x.Adjustment);
		return validator.Results;
	}
}
