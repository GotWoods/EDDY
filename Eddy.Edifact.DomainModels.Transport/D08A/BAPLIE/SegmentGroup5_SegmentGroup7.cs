using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08A;

namespace Eddy.Edifact.DomainModels.Transport.D08A.BAPLIE;

public class SegmentGroup5_SegmentGroup7 {
	[SectionPosition(1)] public DGS_DangerousGoods DangerousGoods { get; set; } = new();
	[SectionPosition(2)] public FTX_FreeText FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup5_SegmentGroup7>(this);
		validator.Required(x => x.DangerousGoods);
		validator.Required(x => x.FreeText);
		return validator.Results;
	}
}
