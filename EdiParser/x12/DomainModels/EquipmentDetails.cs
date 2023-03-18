using System.Collections.Generic;
using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels;

public class EquipmentDetails
{
    public List<string> SealNumbers { get; set; } = new();
    
    public N7_EquipmentDetails LineData { get; set; }
}