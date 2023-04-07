using System.Collections.Generic;
using EdiParser.Attributes;

namespace EdiParser.x12.DomainModels._4010._210;

public class PartyWithChargeDetails: Party
{
    [SectionPosition(6)] public List<Charges> EquipmentDetails { get; set; } = new();
    [SectionPosition(7)] public List<OrderDetail> OrderDetail{ get; set; } = new();
}