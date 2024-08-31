using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D20B;

namespace Eddy.Edifact.DomainModels.Transport.D20B.IFCSUM;

public class SegmentGroup28__SegmentGroup55_SegmentGroup66 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public SEQ_SequenceDetails SequenceDetails { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup28__SegmentGroup55__SegmentGroup66_SegmentGroup67> SegmentGroup67 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28__SegmentGroup55_SegmentGroup66>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.Required(x => x.SequenceDetails);
		validator.CollectionSize(x => x.SegmentGroup67, 0, 9);
		foreach (var item in SegmentGroup67) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
