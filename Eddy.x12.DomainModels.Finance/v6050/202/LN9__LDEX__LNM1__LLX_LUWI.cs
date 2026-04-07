using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Finance.v6050._202;

public class LN9__LDEX__LNM1__LLX_LUWI {
	[SectionPosition(1)] public UWI_UnderwritingInformation UnderwritingInformation { get; set; } = new();
	[SectionPosition(2)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(3)] public REF_ReferenceInformation? ReferenceInformation { get; set; }
	[SectionPosition(4)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9__LDEX__LNM1__LLX_LUWI>(this);
		validator.Required(x => x.UnderwritingInformation);
		validator.CollectionSize(x => x.Information, 0, 10);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		return validator.Results;
	}
}
