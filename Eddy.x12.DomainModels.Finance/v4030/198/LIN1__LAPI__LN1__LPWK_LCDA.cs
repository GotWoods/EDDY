using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._198;

public class LIN1__LAPI__LN1__LPWK_LCDA {
	[SectionPosition(1)] public CDA_ConsumerCreditAccount ConsumerCreditAccount { get; set; } = new();
	[SectionPosition(2)] public List<NM1_IndividualOrOrganizationalName> IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(3)] public QTY_Quantity? Quantity { get; set; }
	[SectionPosition(4)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(5)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1__LAPI__LN1__LPWK_LCDA>(this);
		validator.Required(x => x.ConsumerCreditAccount);
		validator.CollectionSize(x => x.IndividualOrOrganizationalName, 0, 5);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 20);
		validator.CollectionSize(x => x.MessageText, 0, 20);
		return validator.Results;
	}
}
