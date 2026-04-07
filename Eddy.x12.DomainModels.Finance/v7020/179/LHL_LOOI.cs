using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Finance.v7020._179;

public class LHL_LOOI {
	[SectionPosition(1)] public OOI_AssociatedObjectTypeIdentification AssociatedObjectTypeIdentification { get; set; } = new();
	[SectionPosition(2)] public BDS_BinaryDataStructure? BinaryDataStructure { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LOOI>(this);
		validator.Required(x => x.AssociatedObjectTypeIdentification);
		return validator.Results;
	}
}
