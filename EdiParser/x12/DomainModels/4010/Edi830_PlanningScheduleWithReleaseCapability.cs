using EdiParser.x12.Models;

namespace EdiParser.x12.DomainModels._4010;

public class Edi830_PlanningScheduleWithReleaseCapability
{
    public BFR_BeginningSegmentForPlanningSchedule BeginningSegmentForPlanningSchedule { get; set; }
    public XPO_PreassignedPurchaseOrderNumbers PreassignedPurchaseOrderNumbers { get; set; }
    
    //public CUR_

    //public REF_

    public PER_AdministrativeCommunicationsContact AdministrativeCommunicationsContact { get; set; }
    public TAX_TaxReference TaxReference { get; set; }
    public FOB_RelatedInstructions RelatedInstructions { get; set; }
    //public CTP_
    public SAC_ServicePromotionAllowanceOrChargeInformation ServicePromotionAllowanceOrChargeInformation { get; set; }
    public CSH_SalesRequirements SalesRequirements { get; set; }
    public ITD_TermsOfSaleDeferredTermsOfSale TermsOfSale { get; set; }
    public DTM_DateTimeReference DateTimeReference { get; set; }
    public PID_ProductItemDescription ProductItemDescription { get; set; }
    public MEA_Measurements Measurements { get; set; }
    public PWK_Paperwork Paperwork { get; set; }
    public PKG_MarkingPackagingLoading MarkingPackagingLoading { get; set; }
    public TD1_CarrierDetailsQuantityAndWeight CarrierDetailsQuantityAndWeight { get; set; }
    public TD5_CarrierDetailsRoutingSequenceTransitTime CarrierDetailsRoutingSequenceTransitTime { get; set; }
    public TD3_CarrierDetailsEquipment CarrierDetailsEquipment { get; set; }
    public TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth CarrierDetailsSpecialHandlingOrHazardous { get; set; }
    public MAN_MarksAndNumbersInformation MarksAndNumbersInformation { get; set; }


}