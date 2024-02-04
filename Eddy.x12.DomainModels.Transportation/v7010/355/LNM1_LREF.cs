using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Transportation.v7010._355;

public class LNM1_LREF {
	[SectionPosition(1)] public REF_ReferenceInformation ReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1_LREF>(this);
		validator.Required(x => x.ReferenceInformation);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
