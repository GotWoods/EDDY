using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D10B;

namespace Eddy.Edifact.DomainModels.Transport.D10B.IFTSTA;

public class SegmentGroup13__SegmentGroup14_SegmentGroup23 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public List<SGP_SplitGoodsPlacement> SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(4)] public List<DGS_DangerousGoods> DangerousGoods { get; set; } = new();
	[SectionPosition(5)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(6)] public List<GDS_NatureOfCargo> NatureOfCargo { get; set; } = new();
	[SectionPosition(7)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(8)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(9)] public List<SegmentGroup13__SegmentGroup14__SegmentGroup23_SegmentGroup24> SegmentGroup24 {get;set;} = new();
	[SectionPosition(10)] public List<SegmentGroup13__SegmentGroup14__SegmentGroup23_SegmentGroup25> SegmentGroup25 {get;set;} = new();
	[SectionPosition(11)] public List<SegmentGroup13__SegmentGroup14__SegmentGroup23_SegmentGroup26> SegmentGroup26 {get;set;} = new();
	[SectionPosition(12)] public List<SegmentGroup13__SegmentGroup14__SegmentGroup23_SegmentGroup27> SegmentGroup27 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup13__SegmentGroup14_SegmentGroup23>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.SplitGoodsPlacement, 1, 99);
		validator.CollectionSize(x => x.DangerousGoods, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.NatureOfCargo, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.Quantity, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup24, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup25, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup26, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup27, 0, 9);
		foreach (var item in SegmentGroup24) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup25) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup26) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup27) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
