using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._198;

public class LIN1__LAPI__LN1__LPWK_LNX1 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(3)] public ACT_AccountIdentification? AccountIdentification { get; set; }
	[SectionPosition(4)] public List<NM1_IndividualOrOrganizationalName> IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(5)] public PRD_MortgageLoanProductDescription? MortgageLoanProductDescription { get; set; }
	[SectionPosition(6)] public List<PEX_PropertyOrHousingExpense> PropertyOrHousingExpense { get; set; } = new();
	[SectionPosition(7)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(8)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(9)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(10)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(11)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1__LAPI__LN1__LPWK_LNX1>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.LocationIDComponent, 0, 10);
		validator.CollectionSize(x => x.IndividualOrOrganizationalName, 0, 10);
		validator.CollectionSize(x => x.PropertyOrHousingExpense, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 5);
		validator.CollectionSize(x => x.QuantityInformation, 0, 5);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 5);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 10);
		validator.CollectionSize(x => x.MessageText, 0, 20);
		return validator.Results;
	}
}
