using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B;

namespace Eddy.Edifact.DomainModels.Transport.D99B.COPINO;

public class SegmentGroup9_SegmentGroup12 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup9__SegmentGroup12_SegmentGroup13> SegmentGroup13 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9_SegmentGroup12>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup13, 0, 9);
		foreach (var item in SegmentGroup13) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
