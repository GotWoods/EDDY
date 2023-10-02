using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels._4010._204;

public class EquipmentDetails
{
    [SectionPosition(1)]
    public N7_EquipmentDetails Detail { get; set; }

    [SectionPosition(2)]
    public N7A_AccessorialEquipmentDetails AccesorialEquipmentDetails { get; set; }

    [SectionPosition(3)]
    public N7B_AdditionalEquipmentDetails AdditionalEquipmentDetails { get; set; }

    [SectionPosition(4)]
    public List<M7_SealNumbers> SealNumbers { get; set; } = new();
}