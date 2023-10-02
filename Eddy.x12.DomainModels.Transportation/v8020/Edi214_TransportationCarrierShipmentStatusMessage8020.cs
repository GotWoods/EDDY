using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.DomainModels.Transportation.v4010._214;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Transportation.v8020;

public class Edi214_TransportationCarrierShipmentStatusMessage8020
{
    [SectionPosition(1)]
    public B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage Detail { get; set; }

    [SectionPosition(2)]
    public List<MS3_InterlineInformation> InterlineInformation { get; set; } = new();

    [SectionPosition(3)]
    public List<Detail> Details { get; set; } = new();

    public Section ToDocumentSection(string transactionSetControlNumber)
    {
        var s = new Section();
        s.SectionType = "214";
        s.TransactionSetControlNumber = transactionSetControlNumber;

        var mapper = new DomainMapper();
        s.Segments = mapper.MapToSegments(this);
        return s;
    }
}