using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.DomainModels._4010._214;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels._4010;

public class Edi214_TransportationCarrierShipmentStatusMessage
{
    [SectionPosition(1)]
    public B10_BeginningSegmentForTransportationCarrierShipmentStatusMessage Detail { get; set; }

    [SectionPosition(2)]
    public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumbers { get; set; } = new();

    [SectionPosition(3)]
    public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();

    [SectionPosition(4)]
    public List<K1_Remarks> Remarks { get; set; } = new();

    [SectionPosition(5)]
    public List<PartyWithContactAndDate> Parties{ get; set; } = new();
    
    [SectionPosition(6)]
    public List<MS3_InterlineInformation> InterlineInformation { get; set; } = new();

    [SectionPosition(7)]
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