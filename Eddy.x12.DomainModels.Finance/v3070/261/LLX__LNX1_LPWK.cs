using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._261;

public class LLX__LNX1_LPWK {
	[SectionPosition(1)] public PWK_Paperwork Paperwork { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LNX1_LPWK>(this);
		validator.Required(x => x.Paperwork);
		validator.CollectionSize(x => x.DateTimeReference, 0, 2);
		return validator.Results;
	}
}
