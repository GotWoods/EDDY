using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.DomainModels._4010._204;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels._4010;

public class Edi204_MotorCarrierLoadTender
{
    [SectionPosition(1)] public B2_BeginningSegmentForShipmentInformationTransaction ShipmentInformation { get; set; } = new();

    [SectionPosition(2)] public B2A_SetPurpose SetPurpose { get; set; } = new();

    [SectionPosition(3)] public Y6_Authentication Authentication { get; set; }

    [SectionPosition(4)] public C2_BankID BankId { get; set; }

    [SectionPosition(5)] public C3_Currency Currency { get; set; }

    [SectionPosition(6)] public ITD_TermsOfSaleDeferredTermsOfSale TermsOfSale { get; set; }

    [SectionPosition(7)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();

    [SectionPosition(8)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();

    [SectionPosition(9)] public List<G62_DateTime> DateTime { get; set; } = new();

    [SectionPosition(10)] public List<R3_RouteInformationMotor> RouteInformation { get; set; } = new();

    [SectionPosition(11)] public List<H3_SpecialHandlingInstructions> SpecialHandlingInstructions { get; set; } = new();

    [SectionPosition(12)] public List<H6_SpecialServices> SpecialServices { get; set; } = new();

    [SectionPosition(13)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();

    [SectionPosition(14)] public List<K1_Remarks> Remarks { get; set; } = new();

    [SectionPosition(15)] public List<Party> Entities { get; set; } = new();
    [SectionPosition(16)] public List<EquipmentDetails> EquipmentDetails { get; set; } = new();

    //TODO: continue this

    // [SectionPosition(4)] public G62_DateTime OrderDate { get; set; }
    //
    // [SectionPosition(5)] public MS3_InterlineInformation InterlineInformation { get; set; }
    //
    // [SectionPosition(6)] //AT5
    // public List<BillOfLadingHandlingInfo> BillOfLadingHandlingInfo { get; set; } = new();
    //
    // [SectionPosition(7)] public PLD_PalletShipmentInformation PalletInformation { get; set; }
    //
    // [SectionPosition(8)] public List<LH6_HazardousCertification> HazardousCertifications { get; set; } = new();
    //
    // [SectionPosition(9)] public List<NTE_NoteSpecialInstruction> Notes { get; set; } = new();
    //

    //

    //
    //
    // [SectionPosition(12)] //N5
    // public List<StopOffDetails> Stops { get; set; } = new();
    //
    // [SectionPosition(13)] public L3_TotalWeightAndCharges Totals { get; set; }

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