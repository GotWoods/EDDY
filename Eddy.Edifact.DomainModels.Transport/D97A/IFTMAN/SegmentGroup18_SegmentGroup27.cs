using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A;

namespace Eddy.Edifact.DomainModels.Transport.D97A.IFTMAN;

public class SegmentGroup18_SegmentGroup27 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup18__SegmentGroup27_SegmentGroup28> SegmentGroup28 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup18_SegmentGroup27>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup28, 0, 9);
		foreach (var item in SegmentGroup28) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
