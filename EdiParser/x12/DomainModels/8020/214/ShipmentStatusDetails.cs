using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._8020._214;

public class ShipmentStatusDetails
{
    [SectionPosition(1)]
    public AT7_ShipmentStatusDetails Details { get; set; }

    [SectionPosition(2)]
    public MS1_EquipmentShipmentOrRealPropertyLocation Location { get; set; }

    [SectionPosition(3)]
    public List<MS2_EquipmentOrContainerOwnerAndType> EquipmentOrContainerOwnerAndTypes { get; set; } = new();

    [SectionPosition(4)]
    public K1_Remarks Remarks { get; set; }

    [SectionPosition(5)]
    public M7_SealNumbers SealNumbers { get; set; }
}