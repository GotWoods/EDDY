using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D04B;

namespace Eddy.Edifact.DomainModels.Transport.D04B.IFTMAN;

public class SegmentGroup18__SegmentGroup30_SegmentGroup33 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup18__SegmentGroup30__SegmentGroup33_SegmentGroup34> SegmentGroup34 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup18__SegmentGroup30_SegmentGroup33>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup34, 0, 9);
		foreach (var item in SegmentGroup34) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
