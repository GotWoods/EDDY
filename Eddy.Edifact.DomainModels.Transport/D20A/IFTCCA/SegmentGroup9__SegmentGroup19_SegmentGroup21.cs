using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D20A;

namespace Eddy.Edifact.DomainModels.Transport.D20A.IFTCCA;

public class SegmentGroup9__SegmentGroup19_SegmentGroup21 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup9__SegmentGroup19__SegmentGroup21_SegmentGroup22> SegmentGroup22 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9__SegmentGroup19_SegmentGroup21>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup22, 0, 9);
		foreach (var item in SegmentGroup22) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
