using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Finance.v4010._191;

public class LENT_LREF {
	[SectionPosition(1)] public REF_ReferenceIdentification ReferenceIdentification { get; set; } = new();
	[SectionPosition(2)] public SLI_SpecificLoanInformation? SpecificLoanInformation { get; set; }
	[SectionPosition(3)] public GR_GuaranteeResultDetail? GuaranteeResultDetail { get; set; }
	[SectionPosition(4)] public List<DEF_DelayedRepayment> DelayedRepayment { get; set; } = new();
	[SectionPosition(5)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(6)] public List<DB_DisbursementInformation> DisbursementInformation { get; set; } = new();
	[SectionPosition(7)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(8)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(9)] public List<LENT__LREF_LIN1> LIN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT_LREF>(this);
		validator.Required(x => x.ReferenceIdentification);
		validator.CollectionSize(x => x.DelayedRepayment, 0, 100);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 1000);
		validator.CollectionSize(x => x.DisbursementInformation, 0, 10);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 500);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 500);
		validator.CollectionSize(x => x.LIN1, 0, 10);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
