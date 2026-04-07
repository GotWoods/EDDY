using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._262;

public class LLX__LIN1_LYNQ {
	[SectionPosition(1)] public YNQ_YesNoQuestion YesNoQuestion { get; set; } = new();
	[SectionPosition(2)] public REF_ReferenceIdentification ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<LLX__LIN1__LYNQ_LIII> LIII {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LIN1_LYNQ>(this);
		validator.Required(x => x.YesNoQuestion);
		validator.Required(x => x.ReferenceIdentification);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2);
		validator.CollectionSize(x => x.LIII, 1, 50);
		foreach (var item in LIII) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
