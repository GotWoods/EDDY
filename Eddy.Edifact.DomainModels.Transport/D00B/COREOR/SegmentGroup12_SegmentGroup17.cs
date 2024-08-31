using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B;

namespace Eddy.Edifact.DomainModels.Transport.D00B.COREOR;

public class SegmentGroup12_SegmentGroup17 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public MEA_Measurements Measurements { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup12__SegmentGroup17_SegmentGroup18> SegmentGroup18 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup12_SegmentGroup17>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.Required(x => x.Measurements);
		validator.CollectionSize(x => x.SegmentGroup18, 0, 9);
		foreach (var item in SegmentGroup18) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
