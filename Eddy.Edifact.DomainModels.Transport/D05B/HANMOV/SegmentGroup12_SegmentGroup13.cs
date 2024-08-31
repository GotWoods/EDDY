using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05B;

namespace Eddy.Edifact.DomainModels.Transport.D05B.HANMOV;

public class SegmentGroup12_SegmentGroup13 {
	[SectionPosition(1)] public STS_Status Status { get; set; } = new();
	[SectionPosition(2)] public List<PIA_AdditionalProductId> AdditionalProductId { get; set; } = new();
	[SectionPosition(3)] public List<IMD_ItemDescription> ItemDescription { get; set; } = new();
	[SectionPosition(4)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(5)] public List<TCC_ChargeRateCalculations> ChargeRateCalculations { get; set; } = new();
	[SectionPosition(6)] public List<SegmentGroup12__SegmentGroup13_SegmentGroup14> SegmentGroup14 {get;set;} = new();
	[SectionPosition(7)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(8)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(9)] public List<GIN_GoodsIdentityNumber> GoodsIdentityNumber { get; set; } = new();
	[SectionPosition(10)] public List<GIR_RelatedIdentificationNumbers> RelatedIdentificationNumbers { get; set; } = new();
	[SectionPosition(11)] public List<SegmentGroup12__SegmentGroup13_SegmentGroup16> SegmentGroup16 {get;set;} = new();
	[SectionPosition(12)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(13)] public List<SegmentGroup12__SegmentGroup13_SegmentGroup17> SegmentGroup17 {get;set;} = new();
	[SectionPosition(14)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(15)] public List<SegmentGroup12__SegmentGroup13_SegmentGroup18> SegmentGroup18 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup12_SegmentGroup13>(this);
		validator.Required(x => x.Status);
		validator.CollectionSize(x => x.AdditionalProductId, 1, 9);
		validator.CollectionSize(x => x.ItemDescription, 1, 99);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.ChargeRateCalculations, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Quantity, 1, 9);
		validator.CollectionSize(x => x.GoodsIdentityNumber, 1, 99);
		validator.CollectionSize(x => x.RelatedIdentificationNumbers, 1, 99);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup14, 0, 9);
		foreach (var item in SegmentGroup14) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup16) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup17) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup18) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
