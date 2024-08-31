using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D02A;

namespace Eddy.Edifact.DomainModels.Transport.D02A.IFTSTA;

public class SegmentGroup4__SegmentGroup5_SegmentGroup14 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public List<SGP_SplitGoodsPlacement> SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(4)] public List<DGS_DangerousGoods> DangerousGoods { get; set; } = new();
	[SectionPosition(5)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(6)] public List<SegmentGroup4__SegmentGroup5__SegmentGroup14_SegmentGroup15> SegmentGroup15 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup4__SegmentGroup5__SegmentGroup14_SegmentGroup16> SegmentGroup16 {get;set;} = new();
	[SectionPosition(8)] public List<SegmentGroup4__SegmentGroup5__SegmentGroup14_SegmentGroup17> SegmentGroup17 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4__SegmentGroup5_SegmentGroup14>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.SplitGoodsPlacement, 1, 99);
		validator.CollectionSize(x => x.DangerousGoods, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup15, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup16, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup17, 0, 99);
		foreach (var item in SegmentGroup15) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup16) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup17) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
