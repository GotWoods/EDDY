using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19A;

namespace Eddy.Edifact.DomainModels.Transport.D19A.IFTMIN;

public class SegmentGroup20 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public List<TMP_Temperature> Temperature { get; set; } = new();
	[SectionPosition(4)] public List<RNG_RangeDetails> RangeDetails { get; set; } = new();
	[SectionPosition(5)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(6)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(7)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(8)] public List<PIA_AdditionalProductId> AdditionalProductId { get; set; } = new();
	[SectionPosition(9)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(10)] public List<PCD_PercentageDetails> PercentageDetails { get; set; } = new();
	[SectionPosition(11)] public List<SegmentGroup20_SegmentGroup21> SegmentGroup21 {get;set;} = new();
	[SectionPosition(12)] public List<GDS_NatureOfCargo> NatureOfCargo { get; set; } = new();
	[SectionPosition(13)] public List<SegmentGroup20_SegmentGroup22> SegmentGroup22 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup20_SegmentGroup23> SegmentGroup23 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup20_SegmentGroup24> SegmentGroup24 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup20_SegmentGroup25> SegmentGroup25 {get;set;} = new();
	[SectionPosition(17)] public List<SegmentGroup20_SegmentGroup26> SegmentGroup26 {get;set;} = new();
	[SectionPosition(18)] public List<SegmentGroup20_SegmentGroup27> SegmentGroup27 {get;set;} = new();
	[SectionPosition(19)] public List<SegmentGroup20_SegmentGroup29> SegmentGroup29 {get;set;} = new();
	[SectionPosition(20)] public List<SegmentGroup20_SegmentGroup31> SegmentGroup31 {get;set;} = new();
	[SectionPosition(21)] public List<SegmentGroup20_SegmentGroup33> SegmentGroup33 {get;set;} = new();
	[SectionPosition(22)] public List<SegmentGroup20_SegmentGroup34> SegmentGroup34 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup20>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 99);
		validator.CollectionSize(x => x.Temperature, 1, 9);
		validator.CollectionSize(x => x.RangeDetails, 1, 9);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.AdditionalProductId, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.PercentageDetails, 1, 9);
		validator.CollectionSize(x => x.NatureOfCargo, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup21, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup22, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup23, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup24, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup25, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup26, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup27, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup29, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup31, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup33, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup34, 0, 99);
		foreach (var item in SegmentGroup21) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup22) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup23) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup24) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup25) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup26) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup27) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup29) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup31) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup33) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup34) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
