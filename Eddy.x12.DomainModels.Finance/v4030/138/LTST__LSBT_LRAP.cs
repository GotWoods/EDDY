using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._138;

public class LTST__LSBT_LRAP {
	[SectionPosition(1)] public RAP_RequirementAttributeAndProficiency RequirementAttributeAndProficiency { get; set; } = new();
	[SectionPosition(2)] public EMS_EmploymentPosition? EmploymentPosition { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTST__LSBT_LRAP>(this);
		validator.Required(x => x.RequirementAttributeAndProficiency);
		return validator.Results;
	}
}
