using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._189;

public class LIN1_LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public List<EMS_EmploymentPosition> EmploymentPosition { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1_LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.EmploymentPosition, 0, 5);
		return validator.Results;
	}
}
