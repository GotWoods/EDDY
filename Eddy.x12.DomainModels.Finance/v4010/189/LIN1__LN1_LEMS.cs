using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Finance.v4010._189;

public class LIN1__LN1_LEMS {
	[SectionPosition(1)] public EMS_EmploymentPosition EmploymentPosition { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(3)] public QTY_Quantity? Quantity { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1__LN1_LEMS>(this);
		validator.Required(x => x.EmploymentPosition);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 2);
		return validator.Results;
	}
}
