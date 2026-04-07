using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._130;

public class LLX__LSES__LCRS_LMKS {
	[SectionPosition(1)] public MKS_MarksAwarded MarksAwarded { get; set; } = new();
	[SectionPosition(2)] public LUI_LanguageUse? LanguageUse { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LSES__LCRS_LMKS>(this);
		validator.Required(x => x.MarksAwarded);
		return validator.Results;
	}
}
