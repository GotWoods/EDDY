using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;
using Eddy.x12.DomainModels.Finance.v3060._820;

namespace Eddy.x12.DomainModels.Finance.v3060;

public class Edi820_PaymentOrderRemittanceAdvice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BPR_BeginningSegmentForPaymentOrderRemittanceAdvice BeginningSegmentForPaymentOrderRemittanceAdvice { get; set; } = new();
	[SectionPosition(3)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(4)] public TRN_Trace? Trace { get; set; }
	[SectionPosition(5)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(6)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(7)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(8)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(9)] public List<LENT> LENT {get;set;} = new();
	[SectionPosition(10)] public List<LTXP> LTXP {get;set;} = new();
	[SectionPosition(11)] public List<LDED> LDED {get;set;} = new();
	[SectionPosition(12)] public List<LLX> LLX {get;set;} = new();

	//Summary
	[SectionPosition(13)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi820_PaymentOrderRemittanceAdvice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForPaymentOrderRemittanceAdvice);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		

		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LENT, 1, 2147483647);
		validator.CollectionSize(x => x.LTXP, 1, 2147483647);
		validator.CollectionSize(x => x.LDED, 1, 2147483647);
		validator.CollectionSize(x => x.LLX, 1, 2147483647);
		foreach (var item in LENT) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LTXP) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LDED) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
