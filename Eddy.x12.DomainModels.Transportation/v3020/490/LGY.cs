using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._490;

public class LGY {
	[SectionPosition(1)] public GY_Geography Geography { get; set; } = new();
	[SectionPosition(2)] public PRI_ExternalReferenceIdentifier? ExternalReferenceIdentifier { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LGY>(this);
		validator.Required(x => x.Geography);
		return validator.Results;
	}
}
