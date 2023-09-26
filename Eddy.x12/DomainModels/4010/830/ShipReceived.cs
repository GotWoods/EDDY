using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels._4010._830;

public class ShipReceived
{
    [SectionPosition(1)] public SHP_ShippedReceivedInformation ShippedReceivedInformation { get; set; }
    [SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceInformation { get; set; } = new();
}