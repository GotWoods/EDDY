using System.Collections.Generic;
using EdiParser.Attributes;

namespace EdiParser.x12.DomainModels._4010._210;

public class PartyWithEquipmentDetails : Party
{
    [SectionPosition(6)]
    public List<EquipmentDetails> EquipmentDetails { get; set; }
}