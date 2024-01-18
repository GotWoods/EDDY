using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Transportation.v6020._204;

public class L0200 {
	[SectionPosition(1)] public N7_EquipmentDetails EquipmentDetails { get; set; } = new();
	[SectionPosition(2)] public N7A_AccessorialEquipmentDetails? AccessorialEquipmentDetails { get; set; }
	[SectionPosition(3)] public N7B_AdditionalEquipmentDetails? AdditionalEquipmentDetails { get; set; }
	[SectionPosition(4)] public MEA_Measurements? Measurements { get; set; }
	[SectionPosition(5)] public List<M7_SealNumbers> SealNumbers { get; set; } = new();
}
