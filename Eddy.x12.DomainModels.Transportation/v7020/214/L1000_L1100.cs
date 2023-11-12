using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._214;

public class L1000_L1100 {
	[SectionPosition(1)] public AT7_ShipmentStatusDetails ShipmentStatusDetails { get; set; } = new();
	[SectionPosition(2)] public MS1_EquipmentShipmentOrRealPropertyLocation? EquipmentShipmentOrRealPropertyLocation { get; set; }
	[SectionPosition(3)] public List<MS2_EquipmentOrContainerOwnerAndType> EquipmentOrContainerOwnerAndType { get; set; } = new();
	[SectionPosition(4)] public K1_Remarks? Remarks { get; set; }
	[SectionPosition(5)] public M7_SealNumbers? SealNumbers { get; set; }
}
