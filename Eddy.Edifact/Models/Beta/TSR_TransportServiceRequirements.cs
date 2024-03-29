﻿using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.Elements;

namespace Eddy.Edifact.Models.Beta;

public class TSR_TransportServiceRequirements
{
    [Position(1)]
    public C536_ContractAndCarriageCondition ContractAndCarriageCondition { get; set; }

    [Position(2)]
    public C233_Service Service { get; set; }

    [Position(3)]
    public C537_TransportPriority TransportPriority { get; set; }

    [Position(4)]
    public C703_NatureOfCargo NatureOfCargo { get; set; }

    public void Validate()
    {
        var validator = new BasicValidator<TSR_TransportServiceRequirements>(this);
    }
}