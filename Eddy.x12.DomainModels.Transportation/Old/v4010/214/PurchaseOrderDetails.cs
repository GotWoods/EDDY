using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._214;

public class PurchaseOrderDetails
{
    [SectionPosition(1)]
    public SPO_ShipmentPurchaseOrderDetail ShipmentPurchaseOrderDetail { get; set; }

    [SectionPosition(2)]
    public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
}