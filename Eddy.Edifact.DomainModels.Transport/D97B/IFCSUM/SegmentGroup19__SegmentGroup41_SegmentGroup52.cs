using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B;

namespace Eddy.Edifact.DomainModels.Transport.D97B.IFCSUM;

public class SegmentGroup19__SegmentGroup41_SegmentGroup52 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public SEQ_SequenceDetails SequenceDetails { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup19__SegmentGroup41__SegmentGroup52_SegmentGroup53> SegmentGroup53 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup41_SegmentGroup52>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.Required(x => x.SequenceDetails);
		validator.CollectionSize(x => x.SegmentGroup53, 0, 9);
		foreach (var item in SegmentGroup53) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
