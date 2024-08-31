using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D16B;

namespace Eddy.Edifact.DomainModels.Transport.D16B.IFTMCS;

public class SegmentGroup19_SegmentGroup31 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup19__SegmentGroup31_SegmentGroup32> SegmentGroup32 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup19__SegmentGroup31_SegmentGroup33> SegmentGroup33 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup19__SegmentGroup31_SegmentGroup34> SegmentGroup34 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19_SegmentGroup31>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup32, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup33, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup34, 0, 999);
		foreach (var item in SegmentGroup32) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup33) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup34) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
