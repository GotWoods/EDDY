using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.DomainModels.Transportation.v4010._210;

namespace Eddy.x12.DomainModels.Transportation.v4010._210;

public class PartyWithChargeDetails: Party
{
    [SectionPosition(6)] public List<Charges> EquipmentDetails { get; set; } = new();
    [SectionPosition(7)] public List<OrderDetail> OrderDetail{ get; set; } = new();
}