using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Finance.v5040._200;

public class LTLN {
	[SectionPosition(1)] public TLN_Tradeline Tradeline { get; set; } = new();
	[SectionPosition(2)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(3)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(4)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public REF_ReferenceInformation? ReferenceInformation { get; set; }
	[SectionPosition(7)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(8)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(9)] public List<TBI_TradeLineBureauIdentifier> TradeLineBureauIdentifier { get; set; } = new();
	[SectionPosition(10)] public List<PPD_PaymentPatternDetails> PaymentPatternDetails { get; set; } = new();
	[SectionPosition(11)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(12)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(13)] public List<LTLN_LAMT> LAMT {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LTLN>(this);
		validator.Required(x => x.Tradeline);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 4);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 7);
		validator.CollectionSize(x => x.TradeLineBureauIdentifier, 0, 5);
		validator.CollectionSize(x => x.PaymentPatternDetails, 0, 15);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 20);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 10);
		validator.CollectionSize(x => x.LAMT, 0, 6);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
