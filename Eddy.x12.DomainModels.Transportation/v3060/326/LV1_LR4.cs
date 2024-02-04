using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._326;

public class LV1_LR4 {
	[SectionPosition(1)] public R4_Port Port { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LV1_LR4>(this);
		validator.Required(x => x.Port);
		return validator.Results;
	}
}