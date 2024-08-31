using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D16B;

namespace Eddy.Edifact.DomainModels.Transport.D16B.IFCSUM;

public class SegmentGroup28__SegmentGroup55__SegmentGroup70_SegmentGroup73 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup28__SegmentGroup55__SegmentGroup70__SegmentGroup73_SegmentGroup74> SegmentGroup74 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28__SegmentGroup55__SegmentGroup70_SegmentGroup73>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup74, 0, 9);
		foreach (var item in SegmentGroup74) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
