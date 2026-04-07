using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Finance.v4010._198;

public class LIN1__LAPI__LN1__LPWK_LFAA {
	[SectionPosition(1)] public FAA_FinancialAssetAccount FinancialAssetAccount { get; set; } = new();
	[SectionPosition(2)] public List<NM1_IndividualOrOrganizationalName> IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(3)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(4)] public QTY_Quantity? Quantity { get; set; }
	[SectionPosition(5)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(6)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1__LAPI__LN1__LPWK_LFAA>(this);
		validator.Required(x => x.FinancialAssetAccount);
		validator.CollectionSize(x => x.IndividualOrOrganizationalName, 0, 5);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 5);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 5);
		validator.CollectionSize(x => x.MessageText, 0, 20);
		return validator.Results;
	}
}
