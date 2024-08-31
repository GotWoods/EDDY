using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D02A;

namespace Eddy.Edifact.DomainModels.Transport.D02A.IFCSUM;

public class SegmentGroup26__SegmentGroup51_SegmentGroup62 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public SEQ_SequenceDetails SequenceDetails { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup26__SegmentGroup51__SegmentGroup62_SegmentGroup63> SegmentGroup63 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26__SegmentGroup51_SegmentGroup62>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.Required(x => x.SequenceDetails);
		validator.CollectionSize(x => x.SegmentGroup63, 0, 9);
		foreach (var item in SegmentGroup63) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
