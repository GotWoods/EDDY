using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.DomainModels._4010._211;
using Eddy.x12.Internals;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels._4010;

public class Edi211_MotorCarrierBillOfLading
{
    [SectionPosition(1)] public BOL_BeginningSegmentForTheMotorCarrierBillOfLading Details { get; set; }
    [SectionPosition(2)] public B2A_SetPurpose Purpose { get; set; }
    [SectionPosition(3)] public List<MS3_InterlineInformation> InterlineInformation { get; set; } = new();
    [SectionPosition(4)] public MS2_EquipmentOrContainerOwnerAndType EquipmentOrContainerOwner { get; set; }
    [SectionPosition(5)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumbers { get; set; } = new();
    [SectionPosition(6)] public List<G62_DateTime> DateTime { get; set; } = new();
    [SectionPosition(7)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
    [SectionPosition(9)] public List<K1_Remarks> Remarks { get; set; } = new();
    [SectionPosition(10)] public List<Party> Parties { get; set; } = new();
    [SectionPosition(11)] public List<BillOfLadingLine> BillOfLadingLines { get; set; } = new();

    public Section ToDocumentSection(string transactionSetControlNumber)
    {
        var s = new Section();
        s.SectionType = "211";
        s.TransactionSetControlNumber = transactionSetControlNumber;

        var mapper = new DomainMapper();
        s.Segments = mapper.MapToSegments(this);
        return s;
    }
}