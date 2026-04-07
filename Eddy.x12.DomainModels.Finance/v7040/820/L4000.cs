using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Finance.v7040._820;

public class L4000 {
	[SectionPosition(1)] public DED_Deductions Deductions { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L4000>(this);
		validator.Required(x => x.Deductions);
		return validator.Results;
	}
}
