using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._521;

public class LNM1_LPAM {
	[SectionPosition(1)] public PAM_PeriodAmount PeriodAmount { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1_LPAM>(this);
		validator.Required(x => x.PeriodAmount);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		return validator.Results;
	}
}
