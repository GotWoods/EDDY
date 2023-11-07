using System.Collections.Generic;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._210;

public class OrderDetail
{
    public SPO_ShipmentPurchaseOrderDetail Detail { get; set; }
    public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
}