using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._324;

public class LN7 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public ED_EquipmentDescription? EquipmentDescription { get; set; }
	[SectionPosition(3)] public V4_CargoLocationReference? CargoLocationReference { get; set; }
	[SectionPosition(4)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();
	[SectionPosition(5)] public List<H1_HazardousMaterial> HazardousMaterial { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7>(this);
		validator.Required(x => x.EquipmentDetails);
		validator.CollectionSize(x => x.SpecialHandlingInstructions, 0, 5);
		validator.CollectionSize(x => x.HazardousMaterial, 0, 4);
		return validator.Results;
	}
}
