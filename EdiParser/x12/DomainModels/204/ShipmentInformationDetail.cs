using System.Collections.Generic;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels;

public class ShipmentInformationDetail
{
    public L5_DescriptionMarksAndNumbers DescriptionMarksAndNumbers { get; set; }
    public AT8_ShipmentWeightPackagingAndQuantityData ShipmentWeightPackagingQuantity { get; set; }
    public List<L11_BusinessInstructionsAndReferenceNumber> ReferenceNumbers { get; set; } = new();
    public List<MEA_Measurements> Measurements { get; set; } = new();
    public L4_Measurement Measuresment { get; set; }
}