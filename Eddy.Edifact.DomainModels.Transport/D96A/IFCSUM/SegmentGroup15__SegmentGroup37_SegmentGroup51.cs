using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFCSUM;

public class SegmentGroup15__SegmentGroup37_SegmentGroup51 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup15__SegmentGroup37__SegmentGroup51_SegmentGroup52> SegmentGroup52 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup15__SegmentGroup37__SegmentGroup51_SegmentGroup53> SegmentGroup53 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup15__SegmentGroup37__SegmentGroup51_SegmentGroup54> SegmentGroup54 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup15__SegmentGroup37_SegmentGroup51>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup52, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup53, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup54, 0, 999);
		foreach (var item in SegmentGroup52) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup53) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup54) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
