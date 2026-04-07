using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Finance.v7040._201;

public class LLRQ__LIN1_LCDA {
	[SectionPosition(1)] public CDA_ConsumerCreditAccount ConsumerCreditAccount { get; set; } = new();
	[SectionPosition(2)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(3)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(4)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(5)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(6)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(7)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(8)] public List<CRC_ConditionsIndicator> ConditionsIndicator { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLRQ__LIN1_LCDA>(this);
		validator.Required(x => x.ConsumerCreditAccount);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.ConditionsIndicator, 1, 2147483647);
		return validator.Results;
	}
}
