using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D09B;

namespace Eddy.Edifact.DomainModels.Transport.D09B.IFTFCC;

public class SegmentGroup19_SegmentGroup23 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public FTX_FreeText FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19_SegmentGroup23>(this);
		validator.Required(x => x.DangerousGoods);
		validator.Required(x => x.FreeText);
		return validator.Results;
	}
}
