using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._925;

public class LF10 {
	[SectionPosition(1)] public F10_IdentificationOfClaimTracer IdentificationOfClaimTracer { get; set; } = new();
	[SectionPosition(2)] public F02_IdentificationOfShipment? IdentificationOfShipment { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LF10>(this);
		validator.Required(x => x.IdentificationOfClaimTracer);
		return validator.Results;
	}
}
