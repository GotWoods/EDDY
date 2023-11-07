using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._214;

public class ShipmentStatusDetails
{
    [SectionPosition(1)]
    public AT7_ShipmentStatusDetails Details { get; set; }

    [SectionPosition(2)]
    public MS1_EquipmentShipmentOrRealPropertyLocation Location { get; set; }

    [SectionPosition(3)]
    public MS2_EquipmentOrContainerOwnerAndType EquipmentOrContainerOwnerAndTypes { get; set; }
}