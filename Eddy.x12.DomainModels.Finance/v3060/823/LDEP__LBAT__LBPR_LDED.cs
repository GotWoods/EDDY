using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._823;

public class LDEP__LBAT__LBPR_LDED {
	[SectionPosition(1)] public DED_Deductions Deductions { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDEP__LBAT__LBPR_LDED>(this);
		validator.Required(x => x.Deductions);
		return validator.Results;
	}
}
