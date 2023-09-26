using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels._4010._830;

public class ShipDelivery
{
    [SectionPosition(1)] public SDP_ShipDeliveryPattern ShipDeliveryPattern { get; set; }
    [SectionPosition(2)] public List<FST_ForecastSchedule> ForecastSchedules { get; set; } = new();
}