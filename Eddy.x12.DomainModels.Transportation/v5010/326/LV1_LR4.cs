using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Transportation.v5010._326;

public class LV1_LR4 {
	[SectionPosition(1)] public R4_PortOrTerminal PortOrTerminal { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LV1_LR4>(this);
		validator.Required(x => x.PortOrTerminal);
		return validator.Results;
	}
}
