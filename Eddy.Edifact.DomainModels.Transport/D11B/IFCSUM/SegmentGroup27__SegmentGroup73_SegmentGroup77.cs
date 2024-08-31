using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D11B;

namespace Eddy.Edifact.DomainModels.Transport.D11B.IFCSUM;

public class SegmentGroup27__SegmentGroup73_SegmentGroup77 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup27__SegmentGroup73__SegmentGroup77_SegmentGroup78> SegmentGroup78 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup27__SegmentGroup73_SegmentGroup77>(this);
		validator.Required(x => x.DangerousGoods);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup78, 0, 9);
		foreach (var item in SegmentGroup78) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
