using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19A;

namespace Eddy.Edifact.DomainModels.Transport.D19A.IFCSUM;

public class SegmentGroup28__SegmentGroup55_SegmentGroup70 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup28__SegmentGroup55__SegmentGroup70_SegmentGroup71> SegmentGroup71 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup28__SegmentGroup55__SegmentGroup70_SegmentGroup72> SegmentGroup72 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup28__SegmentGroup55__SegmentGroup70_SegmentGroup73> SegmentGroup73 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28__SegmentGroup55_SegmentGroup70>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup71, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup72, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup73, 0, 999);
		foreach (var item in SegmentGroup71) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup72) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup73) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
