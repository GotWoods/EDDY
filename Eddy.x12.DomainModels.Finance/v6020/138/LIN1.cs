using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._138;

public class LIN1 {
	[SectionPosition(1)] public IN1_IndividualIdentification IndividualIdentification { get; set; } = new();
	[SectionPosition(2)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public SSE_EntryAndExitInformation? EntryAndExitInformation { get; set; }
	[SectionPosition(5)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(6)] public IND_AdditionalIndividualDemographicInformation? AdditionalIndividualDemographicInformation { get; set; }
	[SectionPosition(7)] public List<LUI_LanguageUse> LanguageUse { get; set; } = new();
	[SectionPosition(8)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(9)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(10)] public List<COM_CommunicationContactInformation> CommunicationContactInformation { get; set; } = new();
	[SectionPosition(11)] public List<RQS_RequestForInformation> RequestForInformation { get; set; } = new();
	[SectionPosition(12)] public List<SCA_StatisticalCategoryAnalysis> StatisticalCategoryAnalysis { get; set; } = new();
	[SectionPosition(13)] public List<LIN1_LEMS> LEMS {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1>(this);
		validator.Required(x => x.IndividualIdentification);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 1, 10);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 5);
		validator.CollectionSize(x => x.LanguageUse, 0, 5);
		validator.CollectionSize(x => x.CommunicationContactInformation, 0, 5);
		validator.CollectionSize(x => x.RequestForInformation, 1, 2147483647);
		validator.CollectionSize(x => x.StatisticalCategoryAnalysis, 1, 2147483647);
		validator.CollectionSize(x => x.LEMS, 0, 10);
		foreach (var item in LEMS) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
