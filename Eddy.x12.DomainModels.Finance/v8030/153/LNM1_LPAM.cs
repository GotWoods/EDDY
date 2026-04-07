using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Finance.v8030._153;

public class LNM1_LPAM {
	[SectionPosition(1)] public PAM_PeriodAmount PeriodAmount { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<CHB_ChargebackInformation> ChargebackInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1_LPAM>(this);
		validator.Required(x => x.PeriodAmount);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.ChargebackInformation, 1, 2147483647);
		return validator.Results;
	}
}
