using System.Collections.Generic;
using EdiParser.Attributes;
using EdiParser.x12.DomainModels._4010._214;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Internals;

namespace EdiParser.x12.DomainModels._8020;

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