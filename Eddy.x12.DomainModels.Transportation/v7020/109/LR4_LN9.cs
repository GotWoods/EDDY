using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._109;

public class LR4_LN9 {
	[SectionPosition(1)] public N9_ExtendedReferenceInformation ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public SG_ShipmentStatus? ShipmentStatus { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LR4_LN9>(this);
		validator.Required(x => x.ExtendedReferenceInformation);
		return validator.Results;
	}
}
