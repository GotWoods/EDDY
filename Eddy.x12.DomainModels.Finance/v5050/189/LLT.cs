using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Finance.v5050._189;

public class LLT {
	[SectionPosition(1)] public LT_LetterOfRecommendation LetterOfRecommendation { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(3)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(4)] public List<COM_CommunicationContactInformation> CommunicationContactInformation { get; set; } = new();
	[SectionPosition(5)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(6)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(7)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(8)] public List<LTE_LetterOfRecommendationEvaluation> LetterOfRecommendationEvaluation { get; set; } = new();
	[SectionPosition(9)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLT>(this);
		validator.Required(x => x.LetterOfRecommendation);
		validator.CollectionSize(x => x.CommunicationContactInformation, 0, 5);
		validator.CollectionSize(x => x.LetterOfRecommendationEvaluation, 0, 15);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		return validator.Results;
	}
}
