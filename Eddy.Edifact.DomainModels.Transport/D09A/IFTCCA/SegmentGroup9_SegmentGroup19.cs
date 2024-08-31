using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D09A;

namespace Eddy.Edifact.DomainModels.Transport.D09A.IFTCCA;

public class SegmentGroup9_SegmentGroup19 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup9__SegmentGroup19_SegmentGroup20> SegmentGroup20 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup9__SegmentGroup19_SegmentGroup21> SegmentGroup21 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9_SegmentGroup19>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup20, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup21, 0, 999);
		foreach (var item in SegmentGroup20) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup21) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
