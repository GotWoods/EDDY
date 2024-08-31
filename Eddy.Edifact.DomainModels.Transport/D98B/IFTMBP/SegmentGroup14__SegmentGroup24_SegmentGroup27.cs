using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B;

namespace Eddy.Edifact.DomainModels.Transport.D98B.IFTMBP;

public class SegmentGroup14__SegmentGroup24_SegmentGroup27 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup14__SegmentGroup24__SegmentGroup27_SegmentGroup28> SegmentGroup28 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup14__SegmentGroup24_SegmentGroup27>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.SegmentGroup28, 0, 9);
		foreach (var item in SegmentGroup28) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
