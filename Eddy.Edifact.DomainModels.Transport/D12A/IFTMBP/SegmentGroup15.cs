using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D12A;

namespace Eddy.Edifact.DomainModels.Transport.D12A.IFTMBP;

public class SegmentGroup15 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public TMP_Temperature Temperature { get; set; } = new();
	[SectionPosition(4)] public RNG_RangeDetails RangeDetails { get; set; } = new();
	[SectionPosition(5)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(6)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(7)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(8)] public List<SegmentGroup15_SegmentGroup16> SegmentGroup16 {get;set;} = new();
	[SectionPosition(9)] public List<GDS_NatureOfCargo> NatureOfCargo { get; set; } = new();
	[SectionPosition(10)] public List<SegmentGroup15_SegmentGroup17> SegmentGroup17 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup15_SegmentGroup18> SegmentGroup18 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup15_SegmentGroup19> SegmentGroup19 {get;set;} = new();
	[SectionPosition(13)] public List<SegmentGroup15_SegmentGroup20> SegmentGroup20 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup15_SegmentGroup21> SegmentGroup21 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup15_SegmentGroup23> SegmentGroup23 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup15_SegmentGroup25> SegmentGroup25 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup15>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.Required(x => x.HandlingInstructions);
		validator.Required(x => x.Temperature);
		validator.Required(x => x.RangeDetails);
		validator.Required(x => x.TransportMovementDetails);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.NatureOfCargo, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup16, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup17, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup18, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup19, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup20, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup21, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup23, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup25, 0, 9);
		foreach (var item in SegmentGroup16) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup17) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup18) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup19) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup20) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup21) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup23) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup25) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
