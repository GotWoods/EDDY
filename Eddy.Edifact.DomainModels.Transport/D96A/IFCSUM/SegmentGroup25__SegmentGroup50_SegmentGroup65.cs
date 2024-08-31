using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFCSUM;

public class SegmentGroup25__SegmentGroup50_SegmentGroup65 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup25__SegmentGroup50__SegmentGroup65_SegmentGroup66> SegmentGroup66 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup25__SegmentGroup50__SegmentGroup65_SegmentGroup67> SegmentGroup67 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup25__SegmentGroup50__SegmentGroup65_SegmentGroup68> SegmentGroup68 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup25__SegmentGroup50_SegmentGroup65>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup66, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup67, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup68, 0, 999);
		foreach (var item in SegmentGroup66) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup67) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup68) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
