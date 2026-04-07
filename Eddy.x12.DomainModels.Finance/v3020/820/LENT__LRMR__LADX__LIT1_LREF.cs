using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Finance.v3020._820;

public class LENT__LRMR__LADX__LIT1_LREF {
	[SectionPosition(1)] public REF_ReferenceNumbers ReferenceNumbers { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT__LRMR__LADX__LIT1_LREF>(this);
		validator.Required(x => x.ReferenceNumbers);
		return validator.Results;
	}
}
