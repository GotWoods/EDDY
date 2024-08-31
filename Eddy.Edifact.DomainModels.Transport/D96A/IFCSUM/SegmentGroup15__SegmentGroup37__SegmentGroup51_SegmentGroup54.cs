using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFCSUM;

public class SegmentGroup15__SegmentGroup37__SegmentGroup51_SegmentGroup54 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup15__SegmentGroup37__SegmentGroup51__SegmentGroup54_SegmentGroup55> SegmentGroup55 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup15__SegmentGroup37__SegmentGroup51_SegmentGroup54>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup55, 0, 9);
		foreach (var item in SegmentGroup55) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
