using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._179;

public class LNM1_LOOI {
	[SectionPosition(1)] public OOI_AssociatedObjectTypeIdentification AssociatedObjectTypeIdentification { get; set; } = new();
	[SectionPosition(2)] public BDS_BinaryDataStructure? BinaryDataStructure { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1_LOOI>(this);
		validator.Required(x => x.AssociatedObjectTypeIdentification);
		return validator.Results;
	}
}
