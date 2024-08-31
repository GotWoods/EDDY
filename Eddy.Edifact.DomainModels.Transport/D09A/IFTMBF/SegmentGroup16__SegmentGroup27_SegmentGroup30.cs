using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D09A;

namespace Eddy.Edifact.DomainModels.Transport.D09A.IFTMBF;

public class SegmentGroup16__SegmentGroup27_SegmentGroup30 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup16__SegmentGroup27__SegmentGroup30_SegmentGroup31> SegmentGroup31 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup16__SegmentGroup27_SegmentGroup30>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup31, 0, 9);
		foreach (var item in SegmentGroup31) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
