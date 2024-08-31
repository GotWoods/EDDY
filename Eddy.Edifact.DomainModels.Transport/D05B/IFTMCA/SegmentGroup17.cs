using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05B;

namespace Eddy.Edifact.DomainModels.Transport.D05B.IFTMCA;

public class SegmentGroup17 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public TMP_Temperature Temperature { get; set; } = new();
	[SectionPosition(4)] public RNG_RangeDetails RangeDetails { get; set; } = new();
	[SectionPosition(5)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(6)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(7)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(8)] public List<PIA_AdditionalProductId> AdditionalProductId { get; set; } = new();
	[SectionPosition(9)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(10)] public List<SegmentGroup17_SegmentGroup18> SegmentGroup18 {get;set;} = new();
	[SectionPosition(11)] public List<GDS_NatureOfCargo> NatureOfCargo { get; set; } = new();
	[SectionPosition(12)] public List<SegmentGroup17_SegmentGroup19> SegmentGroup19 {get;set;} = new();
	[SectionPosition(13)] public List<SegmentGroup17_SegmentGroup20> SegmentGroup20 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup17_SegmentGroup21> SegmentGroup21 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup17_SegmentGroup22> SegmentGroup22 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup17_SegmentGroup23> SegmentGroup23 {get;set;} = new();
	[SectionPosition(17)] public List<SegmentGroup17_SegmentGroup24> SegmentGroup24 {get;set;} = new();
	[SectionPosition(18)] public List<SegmentGroup17_SegmentGroup26> SegmentGroup26 {get;set;} = new();
	[SectionPosition(19)] public List<SegmentGroup17_SegmentGroup28> SegmentGroup28 {get;set;} = new();
	[SectionPosition(20)] public List<SegmentGroup17_SegmentGroup30> SegmentGroup30 {get;set;} = new();
	[SectionPosition(21)] public List<SegmentGroup17_SegmentGroup31> SegmentGroup31 {get;set;} = new();
	[SectionPosition(22)] public List<SegmentGroup17_SegmentGroup32> SegmentGroup32 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup17>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.Required(x => x.HandlingInstructions);
		validator.Required(x => x.Temperature);
		validator.Required(x => x.RangeDetails);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.AdditionalProductId, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.NatureOfCargo, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup18, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup19, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup20, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup21, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup22, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup23, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup24, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup26, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup28, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup30, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup31, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup32, 0, 9);
		foreach (var item in SegmentGroup18) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup19) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup20) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup21) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup22) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup23) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup24) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup26) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup28) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup30) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup31) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup32) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
