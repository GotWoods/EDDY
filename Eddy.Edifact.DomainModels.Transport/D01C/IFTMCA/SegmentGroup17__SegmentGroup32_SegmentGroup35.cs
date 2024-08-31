using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C;

namespace Eddy.Edifact.DomainModels.Transport.D01C.IFTMCA;

public class SegmentGroup17__SegmentGroup32_SegmentGroup35 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup17__SegmentGroup32__SegmentGroup35_SegmentGroup36> SegmentGroup36 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup17__SegmentGroup32_SegmentGroup35>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup36, 0, 9);
		foreach (var item in SegmentGroup36) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
