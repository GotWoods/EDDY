using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D18B;

namespace Eddy.Edifact.DomainModels.Transport.D18B.IFCSUM;

public class SegmentGroup28_SegmentGroup29 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup28__SegmentGroup29_SegmentGroup30> SegmentGroup30 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28_SegmentGroup29>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup30, 0, 9);
		foreach (var item in SegmentGroup30) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
