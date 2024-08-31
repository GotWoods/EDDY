using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98A;

namespace Eddy.Edifact.DomainModels.Transport.D98A.IFCSUM;

public class SegmentGroup19__SegmentGroup41__SegmentGroup55_SegmentGroup58 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup19__SegmentGroup41__SegmentGroup55__SegmentGroup58_SegmentGroup59> SegmentGroup59 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup41__SegmentGroup55_SegmentGroup58>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup59, 0, 9);
		foreach (var item in SegmentGroup59) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
