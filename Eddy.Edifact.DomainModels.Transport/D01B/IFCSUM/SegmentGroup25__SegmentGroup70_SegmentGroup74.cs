using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01B;

namespace Eddy.Edifact.DomainModels.Transport.D01B.IFCSUM;

public class SegmentGroup25__SegmentGroup70_SegmentGroup74 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup25__SegmentGroup70__SegmentGroup74_SegmentGroup75> SegmentGroup75 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup25__SegmentGroup70_SegmentGroup74>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup75, 0, 9);
		foreach (var item in SegmentGroup75) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
