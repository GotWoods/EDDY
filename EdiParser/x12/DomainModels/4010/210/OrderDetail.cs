using System.Collections.Generic;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._4010._210;

public class OrderDetail
{
    public SPO_ShipmentPurchaseOrderDetail Detail { get; set; }
    public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
}