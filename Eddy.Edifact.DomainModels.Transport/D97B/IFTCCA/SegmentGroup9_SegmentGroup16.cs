using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B;

namespace Eddy.Edifact.DomainModels.Transport.D97B.IFTCCA;

public class SegmentGroup9_SegmentGroup16 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup9__SegmentGroup16_SegmentGroup17> SegmentGroup17 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9_SegmentGroup16>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup17, 0, 9);
		foreach (var item in SegmentGroup17) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
