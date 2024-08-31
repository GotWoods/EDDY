using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D13A;

namespace Eddy.Edifact.DomainModels.Transport.D13A.IFCSUM;

public class SegmentGroup27__SegmentGroup53_SegmentGroup64 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public SEQ_SequenceDetails SequenceDetails { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup27__SegmentGroup53__SegmentGroup64_SegmentGroup65> SegmentGroup65 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup27__SegmentGroup53_SegmentGroup64>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.Required(x => x.SequenceDetails);
		validator.CollectionSize(x => x.SegmentGroup65, 0, 9);
		foreach (var item in SegmentGroup65) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
