using System.Collections.Generic;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._204;

public class OrderDetail
{
    public L5_DescriptionMarksAndNumbers DescriptionMarksAndNumbers { get; set; }
    public AT8_ShipmentWeightPackagingAndQuantityData ShipmentWeightPackagingAndQuantityData { get; set; }
    public List<ShipmentDetailContact> Contacts { get; set; } = new();
}