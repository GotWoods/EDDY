using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D11B;

namespace Eddy.Edifact.DomainModels.Transport.D11B.IFCSUM;

public class SegmentGroup27__SegmentGroup53_SegmentGroup68 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup27__SegmentGroup53__SegmentGroup68_SegmentGroup69> SegmentGroup69 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup27__SegmentGroup53__SegmentGroup68_SegmentGroup70> SegmentGroup70 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup27__SegmentGroup53__SegmentGroup68_SegmentGroup71> SegmentGroup71 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup27__SegmentGroup53_SegmentGroup68>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup69, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup70, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup71, 0, 999);
		foreach (var item in SegmentGroup69) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup70) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup71) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
