﻿using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels._4010._830;

public class Forecast
{
    [SectionPosition(1)] public FST_ForecastSchedule ForecastSchedule { get; set; }
    [SectionPosition(2)] public List<QTY_QuantityInformation> Quantity { get; set; } = new();
    [SectionPosition(3)] public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
    [SectionPosition(4)] public List<CodeInformation> CodeInformations { get; set; } = new();
}