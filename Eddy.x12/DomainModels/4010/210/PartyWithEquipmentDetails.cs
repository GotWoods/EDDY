using System.Collections.Generic;
using Eddy.Core.Attributes;

namespace Eddy.x12.DomainModels._4010._210;

public class PartyWithEquipmentDetails : Party
{
    [SectionPosition(6)]
    public List<EquipmentDetails> EquipmentDetails { get; set; }
}