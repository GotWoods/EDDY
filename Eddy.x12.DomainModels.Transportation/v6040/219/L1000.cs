using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6040;

namespace Eddy.x12.DomainModels.Transportation.v6040._219;

public class L1000 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public N7A_AccessorialEquipmentDetails? AccessorialEquipmentDetails { get; set; }
	[SectionPosition(3)] public N7B_AdditionalEquipmentDetails? AdditionalEquipmentDetails { get; set; }
	[SectionPosition(4)] public MEA_Measurements? Measurements { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L1000>(this);
		validator.Required(x => x.EquipmentDetails);
		return validator.Results;
	}
}
