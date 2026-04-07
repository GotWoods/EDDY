using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Finance.v6010._820;

public class LDED {
	[SectionPosition(1)] public DED_Deductions Deductions { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDED>(this);
		validator.Required(x => x.Deductions);
		return validator.Results;
	}
}
