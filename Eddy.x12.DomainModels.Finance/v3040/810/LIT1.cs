using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Finance.v3040._810;

public class LIT1 {
	[SectionPosition(1)] public IT1_BaselineItemDataInvoice BaselineItemDataInvoice { get; set; } = new();
	[SectionPosition(2)] public CRC_ConditionsIndicator? ConditionsIndicator { get; set; }
	[SectionPosition(3)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(4)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(5)] public List<IT3_AdditionalItemData> AdditionalItemData { get; set; } = new();
	[SectionPosition(6)] public List<TXI_TaxInformation> TaxInformation { get; set; } = new();
	[SectionPosition(7)] public List<CTP_PricingInformation> PricingInformation { get; set; } = new();
	[SectionPosition(8)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(9)] public List<LIT1_LPID> LPID {get;set;} = new();
	[SectionPosition(10)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(11)] public List<PKG_MarkingPackagingLoading> MarkingPackagingLoading { get; set; } = new();
	[SectionPosition(12)] public PO4_ItemPhysicalDetails? ItemPhysicalDetails { get; set; }
	[SectionPosition(13)] public List<ITD_TermsOfSaleDeferredTermsOfSale> TermsOfSaleDeferredTermsOfSale { get; set; } = new();
	[SectionPosition(14)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(15)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(16)] public List<SDQ_DestinationQuantity> DestinationQuantity { get; set; } = new();
	[SectionPosition(17)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(18)] public List<CAD_CarrierDetail> CarrierDetail { get; set; } = new();
	[SectionPosition(19)] public List<L7_TariffReference> TariffReference { get; set; } = new();
	[SectionPosition(20)] public SR_AdvertisingScheduleRequested? AdvertisingScheduleRequested { get; set; }
	[SectionPosition(21)] public List<LIT1_LSAC> LSAC {get;set;} = new();
	[SectionPosition(22)] public List<LIT1_LSLN> LSLN {get;set;} = new();
	[SectionPosition(23)] public List<LIT1_LN1> LN1 {get;set;} = new();
	[SectionPosition(24)] public List<LIT1_LLM> LLM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIT1>(this);
		validator.Required(x => x.BaselineItemDataInvoice);
		validator.CollectionSize(x => x.Quantity, 0, 5);
		validator.CollectionSize(x => x.AdditionalItemData, 0, 5);
		validator.CollectionSize(x => x.TaxInformation, 0, 10);
		validator.CollectionSize(x => x.PricingInformation, 0, 25);
		validator.CollectionSize(x => x.Measurements, 0, 40);
		validator.CollectionSize(x => x.Paperwork, 0, 25);
		validator.CollectionSize(x => x.MarkingPackagingLoading, 0, 25);
		validator.CollectionSize(x => x.TermsOfSaleDeferredTermsOfSale, 0, 2);
		validator.CollectionSize(x => x.ReferenceNumbers, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		validator.CollectionSize(x => x.DestinationQuantity, 0, 500);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.CarrierDetail, 1, 2147483647);
		validator.CollectionSize(x => x.TariffReference, 1, 2147483647);
		validator.CollectionSize(x => x.LPID, 0, 1000);
		validator.CollectionSize(x => x.LSAC, 0, 25);
		validator.CollectionSize(x => x.LSLN, 0, 1000);
		validator.CollectionSize(x => x.LN1, 0, 200);
		validator.CollectionSize(x => x.LLM, 0, 10);
		foreach (var item in LPID) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSAC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSLN) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
