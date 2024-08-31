using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B;

namespace Eddy.Edifact.DomainModels.Transport.D97B.IFCSUM;

public class SegmentGroup19_SegmentGroup20 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup19__SegmentGroup20_SegmentGroup21> SegmentGroup21 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19_SegmentGroup20>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup21, 0, 9);
		foreach (var item in SegmentGroup21) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
