using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._304;

public class LLX_LL0 {
	[SectionPosition(1)] public L0_LineItemQuantityAndWeight LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(3)] public PO4_ItemPhysicalDetails? ItemPhysicalDetails { get; set; }
	[SectionPosition(4)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(5)] public L4_Measurement? Measurement { get; set; }
	[SectionPosition(6)] public List<LH6_HazardousCertification> HazardousCertification { get; set; } = new();
	[SectionPosition(7)] public List<LLX__LL0_LPAL> LPAL {get;set;} = new();
	[SectionPosition(8)] public List<LLX__LL0_LCTP> LCTP {get;set;} = new();
	[SectionPosition(9)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(10)] public List<L12_AlternateLadingDescription> AlternateLadingDescription { get; set; } = new();
	[SectionPosition(11)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(12)] public List<LLX__LL0_LL1> LL1 {get;set;} = new();
	[SectionPosition(13)] public L7_TariffReference? TariffReference { get; set; }
	[SectionPosition(14)] public List<LLX__LL0_LSAC> LSAC {get;set;} = new();
	[SectionPosition(15)] public List<LLX__LL0_LL9> LL9 {get;set;} = new();
	[SectionPosition(16)] public List<X1_ExportLicense> ExportLicense { get; set; } = new();
	[SectionPosition(17)] public List<X2_ImportLicense> ImportLicense { get; set; } = new();
	[SectionPosition(18)] public List<LLX__LL0_LC8> LC8 {get;set;} = new();
	[SectionPosition(19)] public List<LLX__LL0_LH1> LH1 {get;set;} = new();
	[SectionPosition(20)] public List<LLX__LL0_LLH1> LLH1 {get;set;} = new();
	[SectionPosition(21)] public List<LLX__LL0_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LL0>(this);
		validator.Required(x => x.LineItemQuantityAndWeight);
		validator.CollectionSize(x => x.Measurements, 0, 10);
		validator.CollectionSize(x => x.Quantity, 0, 5);
		validator.CollectionSize(x => x.HazardousCertification, 0, 6);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 999);
		validator.CollectionSize(x => x.AlternateLadingDescription, 0, 20);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 100);
		validator.CollectionSize(x => x.ExportLicense, 0, 25);
		validator.CollectionSize(x => x.ImportLicense, 0, 5);
		validator.CollectionSize(x => x.LPAL, 0, 3);
		validator.CollectionSize(x => x.LL1, 0, 20);
		validator.CollectionSize(x => x.LSAC, 0, 10);
		validator.CollectionSize(x => x.LL9, 0, 10);
		validator.CollectionSize(x => x.LC8, 0, 20);
		validator.CollectionSize(x => x.LH1, 0, 10);
		validator.CollectionSize(x => x.LN1, 0, 10);
		foreach (var item in LPAL) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LCTP) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSAC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LL9) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LC8) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
