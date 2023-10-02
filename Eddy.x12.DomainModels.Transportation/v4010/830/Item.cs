using System.Collections.Generic;
using Eddy.Core.Attributes;

using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._830;

public class Item
{
    [SectionPosition(1)] public LIN_ItemIdentification ItemIdentification { get; set; }
    [SectionPosition(2)] public UIT_UnitDetail UnitDetail { get; set; }
    [SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReferences { get; set; } = new();
    [SectionPosition(4)] public List<PO3_AdditionalItemDetail> AdditionalItemDetails { get; set; } = new();
    [SectionPosition(5)] public List<CTP_PricingInformation> PricingInformation { get; set; } = new();
    [SectionPosition(6)] public List<PID_ProductItemDescription> ProductItemDescriptions { get; set; } = new();
    [SectionPosition(7)] public List<MEA_Measurements> Measurements { get; set; } = new();
    [SectionPosition(8)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
    [SectionPosition(9)] public List<PKG_MarkingPackagingLoading> MarkingPackagingLoadings { get; set; } = new();
    [SectionPosition(10)] public PO4_ItemPhysicalDetails ItemPhysicalDetails { get; set; }
    [SectionPosition(11)] public PRS_PartReleaseStatus PartReleaseStatus { get; set; }
    [SectionPosition(12)] public List<REF_ReferenceIdentification> ReferenceInformations { get; set; } = new();
    [SectionPosition(13)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContacts { get; set; } = new();
    [SectionPosition(14)] public List<SAC_ServicePromotionAllowanceOrChargeInformation> ServicePromotionAllowanceOrChargeInformations { get; set; } = new();
    [SectionPosition(15)] public List<ITD_TermsOfSaleDeferredTermsOfSale> TermsOfSaleDeferredTermsOfSales { get; set; } = new();
    [SectionPosition(16)] public List<TAX_TaxReference> TaxReferences { get; set; } = new();
    [SectionPosition(17)] public FOB_FOBRelatedInstructions RelatedInstructions { get; set; } = new();
    [SectionPosition(18)] public List<LDT_LeadTime> LeadTimes { get; set; } = new();
    [SectionPosition(19)] public List<QTY_Quantity> QuantityInformations { get; set; } = new();
    [SectionPosition(20)] public List<ATH_ResourceAuthorization> ResourceAuthorizations { get; set; } = new();
    [SectionPosition(21)] public TD1_CarrierDetailsQuantityAndWeight CarrierDetailsQuantityAndWeight { get; set; }
    [SectionPosition(22)] public List<TD5_CarrierDetailsRoutingSequenceTransitTime> CarrierDetailsRoutingSequenceTransitTimes { get; set; } = new();
    [SectionPosition(23)] public List<TD3_CarrierDetailsEquipment> CarrierDetailsEquipments { get; set; } = new();
    [SectionPosition(24)] public List<TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth> CarrierDetailsSpecialHandling { get; set; } = new();
    [SectionPosition(25)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
    [SectionPosition(26)] public List<DD_DemandDetail> DemandDetails { get; set; } = new();
    [SectionPosition(27)] public List<SubLine> SubLines{ get; set; } = new();
    [SectionPosition(28)] public List<Party> Parties { get; set; } = new();
    [SectionPosition(29)] public List<CodeInformation> CodeInformations{ get; set; } = new();
    [SectionPosition(30)] public List<Forecast> Forecasts { get; set; } = new();
    [SectionPosition(31)] public List<ShipDelivery> ShipDeliveries{ get; set; } = new();
    [SectionPosition(32)] public List<ShipReceived> ShipReceived { get; set; } = new();
}