using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._204;

public class ShipmentInformationDetail
{
    [SectionPosition(1)]
    public L5_DescriptionMarksAndNumbers DescriptionMarksAndNumbers { get; set; }
    [SectionPosition(2)]
    public AT8_ShipmentWeightPackagingAndQuantityData ShipmentWeightPackagingQuantity { get; set; }
    [SectionPosition(3)]
    public List<ShipmentDetailContact> Detail { get; set; } = new();
}