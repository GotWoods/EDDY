using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D10B;

namespace Eddy.Edifact.DomainModels.Transport.D10B.IFTMIN;

public class SegmentGroup19__SegmentGroup33_SegmentGroup36 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup19__SegmentGroup33__SegmentGroup36_SegmentGroup37> SegmentGroup37 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup33_SegmentGroup36>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup37, 0, 9);
		foreach (var item in SegmentGroup37) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
