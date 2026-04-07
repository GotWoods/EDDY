using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._820;

public class LENT__LADX__LIT1_LREF {
	[SectionPosition(1)] public REF_ReferenceIdentification ReferenceIdentification { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT__LADX__LIT1_LREF>(this);
		validator.Required(x => x.ReferenceIdentification);
		return validator.Results;
	}
}
