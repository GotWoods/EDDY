using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._132;

public class LHL__LEMS__LSES_LWLD {
	[SectionPosition(1)] public WLD_WorkloadDetail WorkloadDetail { get; set; } = new();
	[SectionPosition(2)] public N1_Name? Name { get; set; }
	[SectionPosition(3)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(4)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(5)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(6)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(7)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LEMS__LSES_LWLD>(this);
		validator.Required(x => x.WorkloadDetail);
		validator.CollectionSize(x => x.Quantity, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.PercentAmounts, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		return validator.Results;
	}
}
