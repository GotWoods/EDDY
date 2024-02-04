using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._490;

public class L0100 {
	[SectionPosition(1)] public GY_Geography Geography { get; set; } = new();
	[SectionPosition(2)] public PRI_ExternalReferenceIdentifier? ExternalReferenceIdentifier { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0100>(this);
		validator.Required(x => x.Geography);
		return validator.Results;
	}
}
