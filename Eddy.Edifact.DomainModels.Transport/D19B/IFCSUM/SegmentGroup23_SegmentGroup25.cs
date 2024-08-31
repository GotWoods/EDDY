using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19B;

namespace Eddy.Edifact.DomainModels.Transport.D19B.IFCSUM;

public class SegmentGroup23_SegmentGroup25 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup23__SegmentGroup25_SegmentGroup26> SegmentGroup26 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup23_SegmentGroup25>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup26, 0, 9);
		foreach (var item in SegmentGroup26) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
