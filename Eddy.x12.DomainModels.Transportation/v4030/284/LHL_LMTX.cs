using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Transportation.v4030._284;

public class LHL_LMTX {
	[SectionPosition(1)] public MTX_Text Text { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LMTX>(this);
		validator.Required(x => x.Text);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		return validator.Results;
	}
}
