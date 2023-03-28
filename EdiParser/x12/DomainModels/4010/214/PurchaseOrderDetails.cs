using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._4010._214;

public class PurchaseOrderDetails
{
    [SectionPosition(1)]
    public SPO_ShipmentPurchaseOrderDetail ShipmentPurchaseOrderDetail { get; set; }

    [SectionPosition(2)]
    public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
}