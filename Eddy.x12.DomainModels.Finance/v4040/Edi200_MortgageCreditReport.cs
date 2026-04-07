using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;
using Eddy.x12.DomainModels.Finance.v4040._200;

namespace Eddy.x12.DomainModels.Finance.v4040;

public class Edi200_MortgageCreditReport {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public CRO_CreditReportOrderDetails CreditReportOrderDetails { get; set; } = new();
	[SectionPosition(4)] public List<AAA_RequestValidation> RequestValidation { get; set; } = new();
	[SectionPosition(5)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(6)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(7)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(8)] public NX1_PropertyOrEntityIdentification? PropertyOrEntityIdentification { get; set; }
	[SectionPosition(9)] public List<NX2_LocationIDComponent> LocationIDComponent { get; set; } = new();
	[SectionPosition(10)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(11)] public List<LLX> LLX {get;set;} = new();
	[SectionPosition(12)] public List<LTLN> LTLN {get;set;} = new();
	[SectionPosition(13)] public List<LRO> LRO {get;set;} = new();
	[SectionPosition(14)] public List<LCCI> LCCI {get;set;} = new();
	[SectionPosition(15)] public List<LINQ> LINQ {get;set;} = new();
	[SectionPosition(16)] public List<LVAR> LVAR {get;set;} = new();
	[SectionPosition(17)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(18)] public List<LNTE> LNTE {get;set;} = new();
	[SectionPosition(19)] public LE_LoopTrailer? LoopTrailer { get; set; }
	[SectionPosition(20)] public LS_LoopHeader? LoopHeader2 { get; set; }
	[SectionPosition(21)] public List<LREF> LREF {get;set;} = new();
	[SectionPosition(22)] public LE_LoopTrailer? LoopTrailer2 { get; set; }
	[SectionPosition(23)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();



	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi200_MortgageCreditReport>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.Required(x => x.CreditReportOrderDetails);
		validator.CollectionSize(x => x.RequestValidation, 0, 5);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 5);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 3);
		validator.CollectionSize(x => x.LocationIDComponent, 0, 10);
		

		validator.CollectionSize(x => x.LN1, 1, 20);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		

		validator.CollectionSize(x => x.LLX, 1, 2);
		validator.CollectionSize(x => x.LTLN, 0, 1000);
		validator.CollectionSize(x => x.LRO, 0, 500);
		validator.CollectionSize(x => x.LCCI, 0, 5);
		validator.CollectionSize(x => x.LINQ, 0, 100);
		validator.CollectionSize(x => x.LVAR, 0, 25);
		validator.CollectionSize(x => x.LNTE, 0, 20);
		validator.CollectionSize(x => x.LREF, 1, 2147483647);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTLN) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LRO) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LCCI) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LINQ) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LVAR) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LNTE) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LREF) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
