using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFCSUM;

public class SegmentGroup15_SegmentGroup37 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public TMP_Temperature Temperature { get; set; } = new();
	[SectionPosition(4)] public RNG_RangeDetails RangeDetails { get; set; } = new();
	[SectionPosition(5)] public TMD_TransportMovementDetails TransportMovementDetails { get; set; } = new();
	[SectionPosition(6)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(7)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(8)] public List<PIA_AdditionalProductId> AdditionalProductId { get; set; } = new();
	[SectionPosition(9)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(10)] public List<SegmentGroup15__SegmentGroup37_SegmentGroup38> SegmentGroup38 {get;set;} = new();
	[SectionPosition(11)] public List<GDS_NatureOfCargo> NatureOfCargo { get; set; } = new();
	[SectionPosition(12)] public List<SegmentGroup15__SegmentGroup37_SegmentGroup39> SegmentGroup39 {get;set;} = new();
	[SectionPosition(13)] public List<SegmentGroup15__SegmentGroup37_SegmentGroup40> SegmentGroup40 {get;set;} = new();
	[SectionPosition(14)] public List<SegmentGroup15__SegmentGroup37_SegmentGroup41> SegmentGroup41 {get;set;} = new();
	[SectionPosition(15)] public List<SegmentGroup15__SegmentGroup37_SegmentGroup42> SegmentGroup42 {get;set;} = new();
	[SectionPosition(16)] public List<SegmentGroup15__SegmentGroup37_SegmentGroup43> SegmentGroup43 {get;set;} = new();
	[SectionPosition(17)] public List<SegmentGroup15__SegmentGroup37_SegmentGroup44> SegmentGroup44 {get;set;} = new();
	[SectionPosition(18)] public List<SegmentGroup15__SegmentGroup37_SegmentGroup46> SegmentGroup46 {get;set;} = new();
	[SectionPosition(19)] public List<SegmentGroup15__SegmentGroup37_SegmentGroup48> SegmentGroup48 {get;set;} = new();
	[SectionPosition(20)] public List<SegmentGroup15__SegmentGroup37_SegmentGroup50> SegmentGroup50 {get;set;} = new();
	[SectionPosition(21)] public List<SegmentGroup15__SegmentGroup37_SegmentGroup51> SegmentGroup51 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup15_SegmentGroup37>(this);
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
		validator.CollectionSize(x => x.SegmentGroup38, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup39, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup40, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup41, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup42, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup43, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup44, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup46, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup48, 0, 999);
		validator.CollectionSize(x => x.SegmentGroup50, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup51, 0, 9);
		foreach (var item in SegmentGroup38) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup39) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup40) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup41) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup42) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup43) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup44) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup46) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup48) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup50) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup51) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
