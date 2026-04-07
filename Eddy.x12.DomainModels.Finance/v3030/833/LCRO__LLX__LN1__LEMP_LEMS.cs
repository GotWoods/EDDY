using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._833;

public class LCRO__LLX__LN1__LEMP_LEMS {
	[SectionPosition(1)] public EMS_EmploymentPosition EmploymentPosition { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(3)] public List<AIN_Income> Income { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCRO__LLX__LN1__LEMP_LEMS>(this);
		validator.Required(x => x.EmploymentPosition);
		validator.CollectionSize(x => x.Income, 0, 10);
		return validator.Results;
	}
}
