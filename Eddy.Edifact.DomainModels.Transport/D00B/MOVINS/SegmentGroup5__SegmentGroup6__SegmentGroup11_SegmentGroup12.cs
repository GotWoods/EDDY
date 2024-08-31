using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B;

namespace Eddy.Edifact.DomainModels.Transport.D00B.MOVINS;

public class SegmentGroup5__SegmentGroup6__SegmentGroup11_SegmentGroup12 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public FTX_FreeText FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup5__SegmentGroup6__SegmentGroup11_SegmentGroup12>(this);
		validator.Required(x => x.DangerousGoods);
		validator.Required(x => x.FreeText);
		return validator.Results;
	}
}
