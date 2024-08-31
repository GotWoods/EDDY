using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D07B;

namespace Eddy.Edifact.DomainModels.Transport.D07B.IFCSUM;

public class SegmentGroup26__SegmentGroup51_SegmentGroup66 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup26__SegmentGroup51__SegmentGroup66_SegmentGroup67> SegmentGroup67 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup26__SegmentGroup51__SegmentGroup66_SegmentGroup68> SegmentGroup68 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup26__SegmentGroup51__SegmentGroup66_SegmentGroup69> SegmentGroup69 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26__SegmentGroup51_SegmentGroup66>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup67, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup68, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup69, 0, 999);
		foreach (var item in SegmentGroup67) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup68) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup69) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
