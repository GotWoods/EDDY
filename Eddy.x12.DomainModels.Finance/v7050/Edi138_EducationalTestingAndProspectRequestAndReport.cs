using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;
using Eddy.x12.DomainModels.Finance.v7050._138;

namespace Eddy.x12.DomainModels.Finance.v7050;

public class Edi138_EducationalTestingAndProspectRequestAndReport {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public ERP_EducationalRecordPurpose EducationalRecordPurpose { get; set; } = new();
	[SectionPosition(4)] public REF_ReferenceInformation ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(6)] public List<LIN1> LIN1 {get;set;} = new();
	[SectionPosition(7)] public List<LTST> LTST {get;set;} = new();
	[SectionPosition(8)] public List<LDEG> LDEG {get;set;} = new();
	[SectionPosition(9)] public List<LSST> LSST {get;set;} = new();
	[SectionPosition(10)] public List<LPCL> LPCL {get;set;} = new();
	[SectionPosition(11)] public List<LATV> LATV {get;set;} = new();
	[SectionPosition(12)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi138_EducationalTestingAndProspectRequestAndReport>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.EducationalRecordPurpose);
		validator.Required(x => x.ReferenceInformation);
		

		validator.CollectionSize(x => x.LN1, 1, 2);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LIN1, 1, 10);
		validator.CollectionSize(x => x.LTST, 1, 2147483647);
		validator.CollectionSize(x => x.LDEG, 0, 5);
		validator.CollectionSize(x => x.LSST, 0, 10);
		validator.CollectionSize(x => x.LPCL, 0, 25);
		validator.CollectionSize(x => x.LATV, 1, 2147483647);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTST) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LDEG) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LSST) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPCL) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LATV) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
