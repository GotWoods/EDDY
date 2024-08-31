using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B;

namespace Eddy.Edifact.DomainModels.Transport.D00B.IFCSUM;

public class SegmentGroup25__SegmentGroup50_SegmentGroup61 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public SEQ_SequenceDetails SequenceDetails { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup25__SegmentGroup50__SegmentGroup61_SegmentGroup62> SegmentGroup62 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup25__SegmentGroup50_SegmentGroup61>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.Required(x => x.SequenceDetails);
		validator.CollectionSize(x => x.SegmentGroup62, 0, 9);
		foreach (var item in SegmentGroup62) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
