using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Transportation.v3040._304;

public class LLX_LL0 {
	[SectionPosition(1)] public L0_LineItemQuantityAndWeight LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(3)] public PO4_ItemPhysicalDetails? ItemPhysicalDetails { get; set; }
	[SectionPosition(4)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(5)] public L4_Measurement? Measurement { get; set; }
	[SectionPosition(6)] public LH6_HazardousCertification? HazardousCertification { get; set; }
	[SectionPosition(7)] public List<LLX__LL0_LPAL> LPAL {get;set;} = new();
	[SectionPosition(8)] public CTP_PricingInformation? PricingInformation { get; set; }
	[SectionPosition(9)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(10)] public List<L12_AlternateLadingDescription> AlternateLadingDescription { get; set; } = new();
	[SectionPosition(11)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(12)] public List<LLX__LL0_LL1> LL1 {get;set;} = new();
	[SectionPosition(13)] public L7_TariffReference? TariffReference { get; set; }
	[SectionPosition(14)] public List<SAC_ServicePromotionAllowanceOrChargeInformation> ServicePromotionAllowanceOrChargeInformation { get; set; } = new();
	[SectionPosition(15)] public List<L9_ChargeDetail> ChargeDetail { get; set; } = new();
	[SectionPosition(16)] public X1_ExportLicense? ExportLicense { get; set; }
	[SectionPosition(17)] public List<X2_ImportLicense> ImportLicense { get; set; } = new();
	[SectionPosition(18)] public List<LLX__LL0_LC8> LC8 {get;set;} = new();
	[SectionPosition(19)] public List<LLX__LL0_LH1> LH1 {get;set;} = new();
	[SectionPosition(20)] public List<LLX__LL0_LLH1> LLH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LL0>(this);
		validator.Required(x => x.LineItemQuantityAndWeight);
		validator.CollectionSize(x => x.Measurements, 0, 10);
		validator.CollectionSize(x => x.Quantity, 0, 5);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 999);
		validator.CollectionSize(x => x.AlternateLadingDescription, 0, 20);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.ServicePromotionAllowanceOrChargeInformation, 0, 10);
		validator.CollectionSize(x => x.ChargeDetail, 0, 10);
		validator.CollectionSize(x => x.ImportLicense, 0, 5);
		validator.CollectionSize(x => x.LPAL, 0, 3);
		validator.CollectionSize(x => x.LL1, 0, 20);
		validator.CollectionSize(x => x.LC8, 0, 20);
		validator.CollectionSize(x => x.LH1, 0, 10);
		validator.CollectionSize(x => x.LLH1, 0, 100);
		foreach (var item in LPAL) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LC8) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
