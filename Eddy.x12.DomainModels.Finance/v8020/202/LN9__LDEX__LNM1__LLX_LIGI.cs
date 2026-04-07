using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._202;

public class LN9__LDEX__LNM1__LLX_LIGI {
	[SectionPosition(1)] public IGI_InsurerOrGuarantorInformation InsurerOrGuarantorInformation { get; set; } = new();
	[SectionPosition(2)] public REF_ReferenceInformation? ReferenceInformation { get; set; }
	[SectionPosition(3)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9__LDEX__LNM1__LLX_LIGI>(this);
		validator.Required(x => x.InsurerOrGuarantorInformation);
		validator.CollectionSize(x => x.PercentAmounts, 0, 10);
		return validator.Results;
	}
}
