using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._262;

public class LLX__LIN1_LYNQ {
	[SectionPosition(1)] public YNQ_YesNoQuestion YesNoQuestion { get; set; } = new();
	[SectionPosition(2)] public REF_ReferenceNumbers ReferenceNumbers { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(5)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LIN1_LYNQ>(this);
		validator.Required(x => x.YesNoQuestion);
		validator.Required(x => x.ReferenceNumbers);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2);
		validator.CollectionSize(x => x.Information, 1, 50);
		validator.CollectionSize(x => x.MessageText, 0, 5);
		return validator.Results;
	}
}
