using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01A;

namespace Eddy.Edifact.DomainModels.Transport.D01A.IFCSUM;

public class SegmentGroup21_SegmentGroup23 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup21__SegmentGroup23_SegmentGroup24> SegmentGroup24 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup21_SegmentGroup23>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		foreach (var item in SegmentGroup24) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
