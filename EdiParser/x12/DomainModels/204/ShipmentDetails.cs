using System.Collections.Generic;

namespace EdiParser.x12.DomainModels._204;

public class ShipmentDetails
{
    public List<ShipmentDetailContact> Contacts { get; set; } = new();
}