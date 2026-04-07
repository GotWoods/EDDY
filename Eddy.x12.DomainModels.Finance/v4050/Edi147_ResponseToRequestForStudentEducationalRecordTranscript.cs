using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;
using Eddy.x12.DomainModels.Finance.v4050._147;

namespace Eddy.x12.DomainModels.Finance.v4050;

public class Edi147_ResponseToRequestForStudentEducationalRecordTranscript {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public AAA_RequestValidation RequestValidation { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceIdentification> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public PWK_Paperwork? Paperwork { get; set; }
	[SectionPosition(6)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(7)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(8)] public List<LIN1> LIN1 {get;set;} = new();
	[SectionPosition(9)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi147_ResponseToRequestForStudentEducationalRecordTranscript>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.RequestValidation);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 15);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LN1, 1, 2);
		validator.CollectionSize(x => x.LIN1, 1, 15);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
