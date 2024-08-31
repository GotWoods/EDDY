using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D20A;

namespace Eddy.Edifact.DomainModels.Transport.D20A.IFCSUM;

public class SegmentGroup28__SegmentGroup75_SegmentGroup79 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup28__SegmentGroup75__SegmentGroup79_SegmentGroup80> SegmentGroup80 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28__SegmentGroup75_SegmentGroup79>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup80, 0, 9);
		foreach (var item in SegmentGroup80) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
