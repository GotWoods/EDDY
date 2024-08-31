using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08A;

namespace Eddy.Edifact.DomainModels.Transport.D08A.IFCSUM;

public class SegmentGroup22_SegmentGroup24 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup22__SegmentGroup24_SegmentGroup25> SegmentGroup25 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup22_SegmentGroup24>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		foreach (var item in SegmentGroup25) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
