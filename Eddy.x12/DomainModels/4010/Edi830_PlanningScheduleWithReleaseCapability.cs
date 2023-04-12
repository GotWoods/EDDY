using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.x12.DomainModels._4010._830;
using Eddy.x12.Internals;
using Eddy.x12.Models;

namespace Eddy.x12.DomainModels._4010;

public class Edi830_PlanningScheduleWithReleaseCapability
{
    [SectionPosition(1)] public BFR_BeginningSegmentForPlanningSchedule BeginningSegmentForPlanningSchedule { get; set; }
    [SectionPosition(2)] public List<XPO_PreassignedPurchaseOrderNumbers> PreassignedPurchaseOrderNumbers { get; set; } = new();
    [SectionPosition(3)] public CUR_Currency Currency { get; set; }
    [SectionPosition(4)] public List<REF_ReferenceInformation> RefReferenceInformation { get; set; } = new();
    [SectionPosition(5)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
    [SectionPosition(7)] public List<TAX_TaxReference> TaxReference { get; set; } = new();
    [SectionPosition(8)] public FOB_RelatedInstructions RelatedInstructions { get; set; }
    [SectionPosition(9)] public List<CTP_TODO> PricingInformation { get; set; } = new();
    [SectionPosition(10)] public List<SAC_ServicePromotionAllowanceOrChargeInformation> ServicePromotionAllowanceOrChargeInformation { get; set; } = new();
    [SectionPosition(11)] public CSH_SalesRequirements SalesRequirements { get; set; }
    [SectionPosition(12)] public ITD_TermsOfSaleDeferredTermsOfSale TermsOfSale { get; set; }
    [SectionPosition(13)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
    [SectionPosition(14)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
    [SectionPosition(15)] public List<MEA_Measurements> Measurements { get; set; } = new();
    [SectionPosition(16)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
    [SectionPosition(17)] public List<PKG_MarkingPackagingLoading> MarkingPackagingLoading { get; set; } = new();
    [SectionPosition(18)] public List<TD1_CarrierDetailsQuantityAndWeight> CarrierDetailsQuantityAndWeight { get; set; } = new();
    [SectionPosition(19)] public List<TD5_CarrierDetailsRoutingSequenceTransitTime> CarrierDetailsRoutingSequenceTransitTime { get; set; } = new();
    [SectionPosition(20)] public List<TD3_CarrierDetailsEquipment> CarrierDetailsEquipment { get; set; } = new();
    [SectionPosition(21)] public List<TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth> CarrierDetailsSpecialHandlingOrHazardous { get; set; } = new();
    [SectionPosition(22)] public List<MAN_MarksAndNumbersInformation> MarksAndNumbersInformation { get; set; } = new();
    [SectionPosition(23)] public List<Party> Parties { get; set; } = new();
    [SectionPosition(24)] public List<CodeInformation> CodeInformation { get; set; } = new();
    [SectionPosition(25)] public List<Item> Items { get; set; } = new();

    //Summary
    [SectionPosition(26)] public CTT_TransactionTotals TransactionTotals { get; set; }

    public Section ToDocumentSection(string transactionSetControlNumber)
    {
        var s = new Section();
        s.SectionType = "830";
        s.TransactionSetControlNumber = transactionSetControlNumber;

        var mapper = new DomainMapper();
        s.Segments = mapper.MapToSegments(this);
        return s;
    }
}