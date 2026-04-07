using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._264;

public class L0200__L0210_L0212 {
	[SectionPosition(1)] public REC_RealEstateCondition RealEstateCondition { get; set; } = new();
	[SectionPosition(2)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public List<DFI_DefaultInformation> DefaultInformation { get; set; } = new();
	[SectionPosition(5)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(6)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(7)] public INT_Interest? Interest { get; set; }
	[SectionPosition(8)] public List<SOM_StatusOfMortgage> StatusOfMortgage { get; set; } = new();
	[SectionPosition(9)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(10)] public List<MRC_MortgagorResponseCharacteristics> MortgagorResponseCharacteristics { get; set; } = new();
	[SectionPosition(11)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(12)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(13)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200__L0210_L0212>(this);
		validator.Required(x => x.RealEstateCondition);
		validator.CollectionSize(x => x.DefaultInformation, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 10);
		validator.CollectionSize(x => x.StatusOfMortgage, 0, 10);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 14);
		validator.CollectionSize(x => x.MortgagorResponseCharacteristics, 0, 2);
		validator.CollectionSize(x => x.MessageText, 0, 11);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		return validator.Results;
	}
}
