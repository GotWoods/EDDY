using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels;

public class EquipmentDetails
{
    [SectionPosition(1)]
    public N7_EquipmentDetails Details { get; set; }

    [SectionPosition(2)]
    public N7A_AccessorialEquipmentDetails AccessorialEquipmentDetails { get; set; }

    [SectionPosition(3)]
    public N7B_AdditionalEquipmentDetails AdditionalEquipmentDetails { get; set; }

    [SectionPosition(4)] 
    public MEA_Measurements Measurements { get; set; }

    [SectionPosition(5)]
    public List<M7_SealNumbers> SealNumbers { get; set; } = new();
}