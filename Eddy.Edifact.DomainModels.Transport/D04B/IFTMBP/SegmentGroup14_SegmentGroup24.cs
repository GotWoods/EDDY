using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D04B;

namespace Eddy.Edifact.DomainModels.Transport.D04B.IFTMBP;

public class SegmentGroup14_SegmentGroup24 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup14__SegmentGroup24_SegmentGroup25> SegmentGroup25 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup14__SegmentGroup24_SegmentGroup26> SegmentGroup26 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup14__SegmentGroup24_SegmentGroup27> SegmentGroup27 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup14_SegmentGroup24>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup25, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup26, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup27, 0, 999);
		foreach (var item in SegmentGroup25) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup26) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup27) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
