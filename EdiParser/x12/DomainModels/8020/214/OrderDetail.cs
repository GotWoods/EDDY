using System.Collections.Generic;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._8020._214;

public class OrderDetail
{
    public OID_OrderInformationDetail Detail { get; set; }
    public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
}