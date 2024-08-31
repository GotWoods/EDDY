using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D13B;

namespace Eddy.Edifact.DomainModels.Transport.D13B.IFCSUM;

public class SegmentGroup27__SegmentGroup53__SegmentGroup68_SegmentGroup71 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup27__SegmentGroup53__SegmentGroup68__SegmentGroup71_SegmentGroup72> SegmentGroup72 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup27__SegmentGroup53__SegmentGroup68_SegmentGroup71>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup72, 0, 9);
		foreach (var item in SegmentGroup72) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
