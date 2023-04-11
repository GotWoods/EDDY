using System.Collections.Generic;
using Eddy.Core.Attributes;

namespace Eddy.x12.DomainModels._8020._210;

public class PartyWithChargeDetails: Party
{
    [SectionPosition(6)] public List<Charges> EquipmentDetails { get; set; } = new();
    [SectionPosition(7)] public List<OrderDetail> OrderDetail{ get; set; } = new();
}