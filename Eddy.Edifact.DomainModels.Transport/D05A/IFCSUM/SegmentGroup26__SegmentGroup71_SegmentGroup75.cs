using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05A;

namespace Eddy.Edifact.DomainModels.Transport.D05A.IFCSUM;

public class SegmentGroup26__SegmentGroup71_SegmentGroup75 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup26__SegmentGroup71__SegmentGroup75_SegmentGroup76> SegmentGroup76 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26__SegmentGroup71_SegmentGroup75>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup76, 0, 9);
		foreach (var item in SegmentGroup76) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
