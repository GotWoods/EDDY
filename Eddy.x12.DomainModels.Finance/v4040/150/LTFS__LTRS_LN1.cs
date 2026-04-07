using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._150;

public class LTFS__LTRS_LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTFS__LTRS_LN1>(this);
		validator.Required(x => x.Name);
		return validator.Results;
	}
}
