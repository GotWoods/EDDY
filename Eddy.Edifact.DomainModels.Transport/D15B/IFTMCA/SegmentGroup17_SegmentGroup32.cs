using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15B;

namespace Eddy.Edifact.DomainModels.Transport.D15B.IFTMCA;

public class SegmentGroup17_SegmentGroup32 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup17__SegmentGroup32_SegmentGroup33> SegmentGroup33 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup17__SegmentGroup32_SegmentGroup34> SegmentGroup34 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup17__SegmentGroup32_SegmentGroup35> SegmentGroup35 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup17_SegmentGroup32>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup33, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup34, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup35, 0, 999);
		foreach (var item in SegmentGroup33) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup34) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup35) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
