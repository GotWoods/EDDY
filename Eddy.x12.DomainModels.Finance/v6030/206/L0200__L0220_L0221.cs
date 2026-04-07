using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Finance.v6030._206;

public class L0200__L0220_L0221 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	[SectionPosition(6)] public CRC_ConditionsIndicator? ConditionsIndicator { get; set; }
	[SectionPosition(7)] public List<DFI_DefaultInformation> DefaultInformation { get; set; } = new();
	[SectionPosition(8)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(9)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(10)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(11)] public List<OBI_ObligationInformation> ObligationInformation { get; set; } = new();
	[SectionPosition(12)] public List<AIN_Income> Income { get; set; } = new();
	[SectionPosition(13)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200__L0220_L0221>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 10);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.DefaultInformation, 0, 5);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 10);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 5);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.ObligationInformation, 1, 2147483647);
		validator.CollectionSize(x => x.Income, 0, 10);
		validator.CollectionSize(x => x.QuantityInformation, 0, 3);
		return validator.Results;
	}
}
