using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;
using Eddy.x12.DomainModels.Finance.v6030._189;

namespace Eddy.x12.DomainModels.Finance.v6030;

public class Edi189_ApplicationForAdmissionToEducationalInstitutions {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(4)] public List<LREF> LREF {get;set;} = new();
	[SectionPosition(5)] public List<LIN1> LIN1 {get;set;} = new();
	[SectionPosition(6)] public List<LATV> LATV {get;set;} = new();
	[SectionPosition(7)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(8)] public List<LAMT> LAMT {get;set;} = new();
	[SectionPosition(9)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(10)] public List<LSSE> LSSE {get;set;} = new();
	[SectionPosition(11)] public List<LLQ> LLQ {get;set;} = new();
	[SectionPosition(12)] public List<LRSD> LRSD {get;set;} = new();
	[SectionPosition(13)] public List<LRQS> LRQS {get;set;} = new();
	[SectionPosition(14)] public List<LSST> LSST {get;set;} = new();
	[SectionPosition(15)] public List<LTST> LTST {get;set;} = new();
	[SectionPosition(16)] public List<LPCL> LPCL {get;set;} = new();
	[SectionPosition(17)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(18)] public List<LLT> LLT {get;set;} = new();
	[SectionPosition(19)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi189_ApplicationForAdmissionToEducationalInstitutions>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		

		validator.CollectionSize(x => x.LN1, 1, 2);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LREF, 1, 15);
		validator.CollectionSize(x => x.LIN1, 1, 10);
		validator.CollectionSize(x => x.LATV, 1, 2147483647);
		validator.CollectionSize(x => x.LAMT, 0, 15);
		validator.CollectionSize(x => x.LSSE, 0, 5);
		validator.CollectionSize(x => x.LRSD, 1, 2147483647);
		validator.CollectionSize(x => x.LRQS, 1, 2147483647);
		validator.CollectionSize(x => x.LSST, 0, 10);
		validator.CollectionSize(x => x.LTST, 1, 2147483647);
		validator.CollectionSize(x => x.LPCL, 0, 25);
		validator.CollectionSize(x => x.LLT, 0, 15);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LATV) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LAMT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSSE) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLQ) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LRSD) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LRQS) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSST) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTST) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPCL) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
