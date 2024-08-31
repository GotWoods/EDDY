using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D16A;

namespace Eddy.Edifact.DomainModels.Transport.D16A.IFTMBF;

public class SegmentGroup17_SegmentGroup28 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup17__SegmentGroup28_SegmentGroup29> SegmentGroup29 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup17__SegmentGroup28_SegmentGroup30> SegmentGroup30 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup17__SegmentGroup28_SegmentGroup31> SegmentGroup31 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup17_SegmentGroup28>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup29, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup30, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup31, 0, 999);
		foreach (var item in SegmentGroup29) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup30) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup31) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
