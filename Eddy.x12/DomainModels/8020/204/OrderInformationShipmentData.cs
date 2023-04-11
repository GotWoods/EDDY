using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels._8020._204;

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