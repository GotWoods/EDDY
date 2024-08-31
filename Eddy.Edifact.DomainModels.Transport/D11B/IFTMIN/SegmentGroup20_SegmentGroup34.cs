using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D11B;

namespace Eddy.Edifact.DomainModels.Transport.D11B.IFTMIN;

public class SegmentGroup20_SegmentGroup34 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup20__SegmentGroup34_SegmentGroup35> SegmentGroup35 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup20__SegmentGroup34_SegmentGroup36> SegmentGroup36 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup20__SegmentGroup34_SegmentGroup37> SegmentGroup37 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup20_SegmentGroup34>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup35, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup36, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup37, 0, 999);
		foreach (var item in SegmentGroup35) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup36) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup37) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
