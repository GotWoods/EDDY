using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;
using Eddy.x12.DomainModels.Finance.v5030._190;

namespace Eddy.x12.DomainModels.Finance.v5030;

public class Edi190_StudentEnrollmentVerification {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public ENR_SchoolEnrollmentInformation? SchoolEnrollmentInformation { get; set; }
	[SectionPosition(4)] public ERP_EducationalRecordPurpose? EducationalRecordPurpose { get; set; }
	[SectionPosition(5)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(6)] public SST_StudentAcademicStatus? StudentAcademicStatus { get; set; }
	[SectionPosition(7)] public List<SUM_AcademicSummary> AcademicSummary { get; set; } = new();
	[SectionPosition(8)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(9)] public List<LAMT> LAMT {get;set;} = new();
	[SectionPosition(10)] public List<LN1> LN1 {get;set;} = new();
	[SectionPosition(11)] public List<LENT> LENT {get;set;} = new();
	[SectionPosition(12)] public List<LSES> LSES {get;set;} = new();
	[SectionPosition(13)] public List<LDEG> LDEG {get;set;} = new();
	[SectionPosition(14)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();




	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi190_StudentEnrollmentVerification>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		validator.CollectionSize(x => x.AcademicSummary, 0, 6);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LAMT, 1, 2147483647);
		validator.CollectionSize(x => x.LN1, 0, 2);
		validator.CollectionSize(x => x.LENT, 0, 5);
		validator.CollectionSize(x => x.LSES, 0, 100);
		validator.CollectionSize(x => x.LDEG, 0, 10);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LENT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSES) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LDEG) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
