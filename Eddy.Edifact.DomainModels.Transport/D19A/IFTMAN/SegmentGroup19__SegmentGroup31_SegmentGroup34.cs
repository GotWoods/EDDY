using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19A;

namespace Eddy.Edifact.DomainModels.Transport.D19A.IFTMAN;

public class SegmentGroup19__SegmentGroup31_SegmentGroup34 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup19__SegmentGroup31__SegmentGroup34_SegmentGroup35> SegmentGroup35 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup31_SegmentGroup34>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup35, 0, 9);
		foreach (var item in SegmentGroup35) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
