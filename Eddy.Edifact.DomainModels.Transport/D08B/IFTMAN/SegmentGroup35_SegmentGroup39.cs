using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08B;

namespace Eddy.Edifact.DomainModels.Transport.D08B.IFTMAN;

public class SegmentGroup35_SegmentGroup39 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup35__SegmentGroup39_SegmentGroup40> SegmentGroup40 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup35_SegmentGroup39>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup40, 0, 9);
		foreach (var item in SegmentGroup40) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
