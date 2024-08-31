using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19B;

namespace Eddy.Edifact.DomainModels.Transport.D19B.IFCSUM;

public class SegmentGroup28_SegmentGroup55 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public List<TMP_Temperature> Temperature { get; set; } = new();
	[SectionPosition(4)] public List<RNG_RangeDetails> RangeDetails { get; set; } = new();
	[SectionPosition(5)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(6)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(7)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(8)] public List<PIA_AdditionalProductId> AdditionalProductId { get; set; } = new();
	[SectionPosition(9)] public List<GIN_GoodsIdentityNumber> GoodsIdentityNumber { get; set; } = new();
	[SectionPosition(10)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(11)] public List<SegmentGroup28__SegmentGroup55_SegmentGroup56> SegmentGroup56 {get;set;} = new();
	[SectionPosition(12)] public List<GDS_NatureOfCargo> NatureOfCargo { get; set; } = new();
	[SectionPosition(13)] public List<SegmentGroup28__SegmentGroup55_SegmentGroup57> SegmentGroup57 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup28__SegmentGroup55_SegmentGroup58> SegmentGroup58 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup28__SegmentGroup55_SegmentGroup59> SegmentGroup59 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup28__SegmentGroup55_SegmentGroup60> SegmentGroup60 {get;set;} = new();
	[SectionPosition(17)] public List<SegmentGroup28__SegmentGroup55_SegmentGroup61> SegmentGroup61 {get;set;} = new();
	[SectionPosition(18)] public List<SegmentGroup28__SegmentGroup55_SegmentGroup62> SegmentGroup62 {get;set;} = new();
	[SectionPosition(19)] public List<SegmentGroup28__SegmentGroup55_SegmentGroup64> SegmentGroup64 {get;set;} = new();
	[SectionPosition(20)] public List<SegmentGroup28__SegmentGroup55_SegmentGroup66> SegmentGroup66 {get;set;} = new();
	[SectionPosition(21)] public List<SegmentGroup28__SegmentGroup55_SegmentGroup68> SegmentGroup68 {get;set;} = new();
	[SectionPosition(22)] public List<SegmentGroup28__SegmentGroup55_SegmentGroup69> SegmentGroup69 {get;set;} = new();
	[SectionPosition(23)] public List<SegmentGroup28__SegmentGroup55_SegmentGroup70> SegmentGroup70 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28_SegmentGroup55>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.Required(x => x.HandlingInstructions);
		validator.CollectionSize(x => x.Temperature, 1, 9);
		validator.CollectionSize(x => x.RangeDetails, 1, 9);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.AdditionalProductId, 1, 9);
		validator.CollectionSize(x => x.GoodsIdentityNumber, 1, 99);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.NatureOfCargo, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup56, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup57, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup58, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup59, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup60, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup61, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup62, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup64, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup66, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup68, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup69, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup70, 0, 99);
		foreach (var item in SegmentGroup56) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup57) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup58) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup59) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup60) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup61) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup62) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup64) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup66) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup68) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup69) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup70) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
