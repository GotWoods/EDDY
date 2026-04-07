using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;
using Eddy.x12.DomainModels.Finance.v3030._146;

namespace Eddy.x12.DomainModels.Finance.v3030;

public class Edi146_RequestForStudentEducationalRecordTranscript {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public ERP_EducationalRecordPurpose EducationalRecordPurpose { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(5)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(6)] public IND_AdditionalIndividualDemographicInformation? AdditionalIndividualDemographicInformation { get; set; }
	[SectionPosition(7)] public SSE_EntryAndExitDates? EntryAndExitDates { get; set; }
	[SectionPosition(8)] public SST_StudentAcademicStatus? StudentAcademicStatus { get; set; }
	[SectionPosition(9)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(10)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(11)] public List<LIN1> LIN1 {get;set;} = new();
	[SectionPosition(12)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi146_RequestForStudentEducationalRecordTranscript>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.EducationalRecordPurpose);
		validator.CollectionSize(x => x.ReferenceNumbers, 1, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 15);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 1, 2);
		validator.CollectionSize(x => x.LIN1, 1, 15);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
