using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Finance.v5050._189;

public class LIN1 {
	[SectionPosition(1)] public IN1_IndividualIdentification IndividualIdentification { get; set; } = new();
	[SectionPosition(2)] public List<IN2_IndividualNameStructureComponents> IndividualNameStructureComponents { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(4)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(5)] public IND_AdditionalIndividualDemographicInformation? AdditionalIndividualDemographicInformation { get; set; }
	[SectionPosition(6)] public List<IMM_ImmunizationStatus> ImmunizationStatus { get; set; } = new();
	[SectionPosition(7)] public List<HC_HealthCondition> HealthCondition { get; set; } = new();
	[SectionPosition(8)] public List<LUI_LanguageUse> LanguageUse { get; set; } = new();
	[SectionPosition(9)] public List<III_Information> Information { get; set; } = new();
	[SectionPosition(10)] public NTE_NoteSpecialInstruction? NoteSpecialInstruction { get; set; }
	[SectionPosition(11)] public List<LIN1_LN3> LN3 {get;set;} = new();
	[SectionPosition(12)] public List<LIN1_LCOM> LCOM {get;set;} = new();
	[SectionPosition(13)] public List<LIN1_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIN1>(this);
		validator.Required(x => x.IndividualIdentification);
		validator.CollectionSize(x => x.IndividualNameStructureComponents, 1, 10);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.ImmunizationStatus, 1, 2147483647);
		validator.CollectionSize(x => x.HealthCondition, 1, 2147483647);
		validator.CollectionSize(x => x.LanguageUse, 1, 2147483647);
		validator.CollectionSize(x => x.Information, 0, 10);
		validator.CollectionSize(x => x.LN3, 0, 5);
		validator.CollectionSize(x => x.LCOM, 0, 10);
		validator.CollectionSize(x => x.LN1, 0, 5);
		foreach (var item in LN3) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LCOM) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
