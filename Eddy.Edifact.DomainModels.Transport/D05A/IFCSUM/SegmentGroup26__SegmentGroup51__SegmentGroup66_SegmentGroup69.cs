using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05A;

namespace Eddy.Edifact.DomainModels.Transport.D05A.IFCSUM;

public class SegmentGroup26__SegmentGroup51__SegmentGroup66_SegmentGroup69 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup26__SegmentGroup51__SegmentGroup66__SegmentGroup69_SegmentGroup70> SegmentGroup70 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26__SegmentGroup51__SegmentGroup66_SegmentGroup69>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup70, 0, 9);
		foreach (var item in SegmentGroup70) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
