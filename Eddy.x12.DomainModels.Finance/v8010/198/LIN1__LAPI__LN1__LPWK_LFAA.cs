using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._198;

public class LIN1__LAPI__LN1__LPWK_LFAA {
	[SectionPosition(1)] public FAA_FinancialAssetAccount FinancialAssetAccount { get; set; } = new();
	[SectionPosition(2)] public List<NM1_IndividualOrOrganizationalName> IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(3)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(4)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(5)] public List<LIN1__LAPI__LN1__LPWK__LFAA_LDTP> LDTP {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1__LAPI__LN1__LPWK_LFAA>(this);
		validator.Required(x => x.FinancialAssetAccount);
		validator.CollectionSize(x => x.IndividualOrOrganizationalName, 0, 5);
		validator.CollectionSize(x => x.MessageText, 0, 20);
		validator.CollectionSize(x => x.LDTP, 1, 2147483647);
		foreach (var item in LDTP) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
