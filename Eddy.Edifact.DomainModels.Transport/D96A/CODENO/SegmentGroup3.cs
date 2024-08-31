using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.CODENO;

public class SegmentGroup3 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup3_SegmentGroup4> SegmentGroup4 {get;set;} = new();
	[SectionPosition(3)] public List<SGP_SplitGoodsPlacement> SplitGoodsPlacement { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.CollectionSize(x => x.SplitGoodsPlacement, 1, 999);
		validator.CollectionSize(x => x.SegmentGroup4, 0, 9);
		foreach (var item in SegmentGroup4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
