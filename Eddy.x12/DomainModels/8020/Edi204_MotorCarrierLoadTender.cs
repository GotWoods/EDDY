using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.DomainModels._8020._204;
using Eddy.x12.Internals;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels._8020;

public class Edi204_MotorCarrierLoadTender
{
    [SectionPosition(1)] public B2_BeginningSegmentForShipmentInformationTransaction ShipmentInformation { get; set; } = new();

    [SectionPosition(2)] public B2A_SetPurpose SetPurpose { get; set; }

    [SectionPosition(3)] public List<L11_BusinessInstructionsAndReferenceNumber> ReferenceNumbers { get; set; } = new();

    [SectionPosition(4)] public G62_DateTime OrderDate { get; set; }

    [SectionPosition(5)] public MS3_InterlineInformation InterlineInformation { get; set; }

    [SectionPosition(6)] //AT5
    public List<BillOfLadingHandlingInfo> BillOfLadingHandlingInfo { get; set; } = new();

    [SectionPosition(7)] public PLD_PalletShipmentInformation PalletInformation { get; set; }

    [SectionPosition(8)] public List<LH6_HazardousCertification> HazardousCertifications { get; set; } = new();

    [SectionPosition(9)] public List<NTE_Note> Notes { get; set; } = new();

    [SectionPosition(10)] //N1
    public List<Entity> Entities { get; set; } = new();

    [SectionPosition(11)] //N7
    public List<EquipmentDetails> EquipmentDetails { get; set; } = new();


    [SectionPosition(12)] //N5
    public List<StopOffDetails> Stops { get; set; } = new();

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