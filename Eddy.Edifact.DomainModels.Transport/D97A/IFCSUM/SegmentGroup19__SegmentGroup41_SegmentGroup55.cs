using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A;

namespace Eddy.Edifact.DomainModels.Transport.D97A.IFCSUM;

public class SegmentGroup19__SegmentGroup41_SegmentGroup55 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup19__SegmentGroup41__SegmentGroup55_SegmentGroup56> SegmentGroup56 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup19__SegmentGroup41__SegmentGroup55_SegmentGroup57> SegmentGroup57 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup19__SegmentGroup41__SegmentGroup55_SegmentGroup58> SegmentGroup58 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup41_SegmentGroup55>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup56, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup57, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup58, 0, 999);
		foreach (var item in SegmentGroup56) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup57) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup58) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
