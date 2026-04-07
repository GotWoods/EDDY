using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._203;

public class LLX__LRLT_LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public N2_AdditionalNameInformation AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(5)] public YNQ_YesNoQuestion YesNoQuestion { get; set; } = new();
	[SectionPosition(6)] public List<LLX__LRLT__LN1_LAMT> LAMT {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LRLT_LN1>(this);
		validator.Required(x => x.Name);
		validator.Required(x => x.AdditionalNameInformation);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 2);
		validator.Required(x => x.YesNoQuestion);
		validator.CollectionSize(x => x.LAMT, 0, 5);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
