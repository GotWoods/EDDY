using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D02A;

namespace Eddy.Edifact.DomainModels.Transport.D02A.IFTFCC;

public class SegmentGroup28__SegmentGroup37_SegmentGroup41 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public FTX_FreeText FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28__SegmentGroup37_SegmentGroup41>(this);
		validator.Required(x => x.DangerousGoods);
		validator.Required(x => x.FreeText);
		return validator.Results;
	}
}
