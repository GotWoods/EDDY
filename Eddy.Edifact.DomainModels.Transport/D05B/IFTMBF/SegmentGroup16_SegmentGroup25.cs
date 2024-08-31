using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05B;

namespace Eddy.Edifact.DomainModels.Transport.D05B.IFTMBF;

public class SegmentGroup16_SegmentGroup25 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup16__SegmentGroup25_SegmentGroup26> SegmentGroup26 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup16_SegmentGroup25>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup26, 0, 9);
		foreach (var item in SegmentGroup26) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
