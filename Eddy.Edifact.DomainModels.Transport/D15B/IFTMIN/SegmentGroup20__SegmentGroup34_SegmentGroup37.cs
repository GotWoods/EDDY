using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15B;

namespace Eddy.Edifact.DomainModels.Transport.D15B.IFTMIN;

public class SegmentGroup20__SegmentGroup34_SegmentGroup37 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup20__SegmentGroup34__SegmentGroup37_SegmentGroup38> SegmentGroup38 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup20__SegmentGroup34_SegmentGroup37>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup38, 0, 9);
		foreach (var item in SegmentGroup38) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
