using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19B;

namespace Eddy.Edifact.DomainModels.Transport.D19B.IFTMAN;

public class SegmentGroup19_SegmentGroup28 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup19__SegmentGroup28_SegmentGroup29> SegmentGroup29 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19_SegmentGroup28>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup29, 0, 9);
		foreach (var item in SegmentGroup29) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
