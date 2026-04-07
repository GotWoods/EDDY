using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._202;

public class LN9__LDEX__LNM1__LLX_LCRC {
	[SectionPosition(1)] public CRC_ConditionsIndicator ConditionsIndicator { get; set; } = new();
	[SectionPosition(2)] public IN1_IndividualIdentification? IndividualIdentification { get; set; }
	[SectionPosition(3)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(4)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(5)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(6)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(7)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(8)] public List<AIN_Income> Income { get; set; } = new();
	[SectionPosition(9)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(10)] public List<LN9__LDEX__LNM1__LLX__LCRC_LSCM> LSCM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN9__LDEX__LNM1__LLX_LCRC>(this);
		validator.Required(x => x.ConditionsIndicator);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 0, 30);
		validator.CollectionSize(x => x.QuantityInformation, 0, 10);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 5);
		validator.CollectionSize(x => x.Income, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 15);
		validator.CollectionSize(x => x.LSCM, 1, 2147483647);
		foreach (var item in LSCM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
