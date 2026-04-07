using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Finance.v7060._824;

public class LOTI__LTED_LREF {
	[SectionPosition(1)] public REF_ReferenceInformation ReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public OOI_AssociatedObjectTypeIdentification AssociatedObjectTypeIdentification { get; set; } = new();
	[SectionPosition(3)] public BDS_BinaryDataStructure BinaryDataStructure { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LOTI__LTED_LREF>(this);
		validator.Required(x => x.ReferenceInformation);
		validator.Required(x => x.AssociatedObjectTypeIdentification);
		validator.Required(x => x.BinaryDataStructure);
		return validator.Results;
	}
}
