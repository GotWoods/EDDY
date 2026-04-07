using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;
using Eddy.x12.DomainModels.Finance.v8030._820;

namespace Eddy.x12.DomainModels.Finance.v8030;

public class Edi820_PaymentOrderRemittanceAdvice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BPR_BeginningSegmentForPaymentOrderRemittanceAdvice BeginningSegmentForPaymentOrderRemittanceAdvice { get; set; } = new();
	[SectionPosition(3)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(4)] public TRN_Trace? Trace { get; set; }
	[SectionPosition(5)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(6)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(8)] public List<L1000> L1000 {get;set;} = new();

	//Details
	[SectionPosition(9)] public List<L2000> L2000 {get;set;} = new();
	[SectionPosition(10)] public List<L3000> L3000 {get;set;} = new();
	[SectionPosition(11)] public List<L4000> L4000 {get;set;} = new();
	[SectionPosition(12)] public List<L5000> L5000 {get;set;} = new();
	[SectionPosition(13)] public List<L6000> L6000 {get;set;} = new();
	[SectionPosition(14)] public List<L7000> L7000 {get;set;} = new();
	[SectionPosition(15)] public List<L8000> L8000 {get;set;} = new();
	[SectionPosition(16)] public List<L9000> L9000 {get;set;} = new();

	//Summary
	[SectionPosition(17)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi820_PaymentOrderRemittanceAdvice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForPaymentOrderRemittanceAdvice);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		

		validator.CollectionSize(x => x.L1000, 1, 2147483647);
		foreach (var item in L1000) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.L2000, 1, 2147483647);
		validator.CollectionSize(x => x.L3000, 1, 2147483647);
		validator.CollectionSize(x => x.L4000, 1, 2147483647);
		validator.CollectionSize(x => x.L5000, 1, 2147483647);
		validator.CollectionSize(x => x.L7000, 1, 2147483647);
		validator.CollectionSize(x => x.L8000, 1, 2147483647);
		validator.CollectionSize(x => x.L9000, 1, 2147483647);
		foreach (var item in L2000) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L3000) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L4000) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L5000) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L6000) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L7000) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L8000) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L9000) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
