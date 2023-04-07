using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._4010._210;

public class EquipmentDetails
{
    [SectionPosition(1)]
    public N7_EquipmentDetails Detail { get; set; }
    
    [SectionPosition(5)]
    public List<M7_SealNumbers> SealNumbers { get; set; } = new();
}