using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.DomainModels.Transportation.v4010._204;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.Old.v4010;

public class Edi204_MotorCarrierLoadTender
{
    [SectionPosition(1)] public B2_BeginningSegmentForShipmentInformationTransaction ShipmentInformation { get; set; } = new();

    [SectionPosition(2)] public B2A_SetPurpose SetPurpose { get; set; } = new();

    [SectionPosition(3)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumbers { get; set; } = new();

    [SectionPosition(4)] public G62_DateTime DateTime { get; set; }

    [SectionPosition(5)] public MS3_InterlineInformation InterlineInformation { get; set; }
    [SectionPosition(6)] public List<AT5_BillOfLadingHandlingRequirements> BillOfLadingHandlingRequirements { get; set; } = new();
    [SectionPosition(7)] public PLD_PalletInformation PalletInformation { get; set; }
    [SectionPosition(8)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
    [SectionPosition(9)] public List<NTE_NoteSpecialInstruction> Notes { get; set; } = new();
    [SectionPosition(10)] public List<Party> Entities { get; set; } = new();
    [SectionPosition(11)] public List<EquipmentDetails> EquipmentDetails { get; set; } = new();
    [SectionPosition(12)] public List<StopOffDetails> StopOffDetails { get; set; } = new();
    [SectionPosition(13)] public L3_TotalWeightAndCharges Totals { get; set; }

    public Section ToDocumentSection(string transactionSetControlNumber)
    {
        var s = new Section();
        s.SectionType = "204";
        s.TransactionSetControlNumber = transactionSetControlNumber;

        var mapper = new DomainMapper();
        s.Segments = mapper.MapToSegments(this);
        return s;
    }

    public void Validate()
    {
        //needs a b2 entry
        //needs a b2a entry
    }
}