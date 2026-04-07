using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;
using Eddy.x12.DomainModels.Finance.v4050._130;

namespace Eddy.x12.DomainModels.Finance.v4050;

public class Edi130_StudentEducationalRecordTranscript {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public ERP_EducationalRecordPurpose EducationalRecordPurpose { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceIdentification> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(6)] public List<LUI_LanguageUse> LanguageUse { get; set; } = new();
	[SectionPosition(7)] public List<IND_AdditionalIndividualDemographicInformation> AdditionalIndividualDemographicInformation { get; set; } = new();
	[SectionPosition(8)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(9)] public List<RAP_RequirementAttributeAndProficiency> RequirementAttributeAndProficiency { get; set; } = new();
	[SectionPosition(10)] public List<PCL_PreviousCollege> PreviousCollege { get; set; } = new();
	[SectionPosition(11)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(12)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(13)] public List<LIN1> LIN1 {get;set;} = new();
	[SectionPosition(14)] public List<LSST> LSST {get;set;} = new();
	[SectionPosition(15)] public List<LATV> LATV {get;set;} = new();
	[SectionPosition(16)] public List<LTST> LTST {get;set;} = new();
	[SectionPosition(17)] public List<LSUM> LSUM {get;set;} = new();

	//Details
	[SectionPosition(18)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(19)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi130_StudentEducationalRecordTranscript>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.EducationalRecordPurpose);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 10);
		validator.CollectionSize(x => x.LanguageUse, 1, 2147483647);
		validator.CollectionSize(x => x.AdditionalIndividualDemographicInformation, 0, 2);
		validator.CollectionSize(x => x.RequirementAttributeAndProficiency, 1, 2147483647);
		validator.CollectionSize(x => x.PreviousCollege, 0, 30);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 100);
		

		validator.CollectionSize(x => x.LN1, 1, 2);
		validator.CollectionSize(x => x.LIN1, 1, 15);
		validator.CollectionSize(x => x.LSST, 0, 500);
		validator.CollectionSize(x => x.LATV, 0, 100);
		validator.CollectionSize(x => x.LTST, 1, 2147483647);
		validator.CollectionSize(x => x.LSUM, 0, 5);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSST) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LATV) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTST) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSUM) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
