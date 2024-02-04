using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._357;

public class LP4_LM21 {
	[SectionPosition(1)] public M21_SupplementaryInBondInformation SupplementaryInBondInformation { get; set; } = new();
	[SectionPosition(2)] public M12_InBondIdentifyingInformation InBondIdentifyingInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4_LM21>(this);
		validator.Required(x => x.SupplementaryInBondInformation);
		validator.Required(x => x.InBondIdentifyingInformation);
		return validator.Results;
	}
}
