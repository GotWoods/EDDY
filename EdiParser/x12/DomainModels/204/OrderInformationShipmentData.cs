using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._204;

public class OrderInformationShipmentData
{
    [SectionPosition(1)] 
    public L5_DescriptionMarksAndNumbers DescriptionMarksAndNumbers { get; set; }

    [SectionPosition(2)]
    public AT8_ShipmentWeightPackagingAndQuantityData ShipmentWeightPackagingAndQuantity { get; set; }

    [SectionPosition(3)]
    public L4_Measurement Measurement { get; set; }


    [SectionPosition(4)]
    public List<HazMatContact> HazMat { get; set; } = new();
}