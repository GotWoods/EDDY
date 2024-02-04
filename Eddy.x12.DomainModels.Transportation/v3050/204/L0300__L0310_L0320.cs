using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._204;

public class L0300__L0310_L0320 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public N7A_AccessorialEquipmentDetails? AccessorialEquipmentDetails { get; set; }
	[SectionPosition(3)] public N7B_AdditionalEquipmentDetails? AdditionalEquipmentDetails { get; set; }
	[SectionPosition(4)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300__L0310_L0320>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.SealNumbers, 0, 2);
		return validator.Results;
	}
}
