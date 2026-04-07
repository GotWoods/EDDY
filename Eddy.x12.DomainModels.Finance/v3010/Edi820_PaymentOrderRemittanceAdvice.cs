using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3010;
using Eddy.x12.DomainModels.Finance.v3010._820;

namespace Eddy.x12.DomainModels.Finance.v3010;

public class Edi820_PaymentOrderRemittanceAdvice {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BPS_BeginningSegmentForPaymentOrderRemittanceAdvice BeginningSegmentForPaymentOrderRemittanceAdvice { get; set; } = new();
	[SectionPosition(3)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(4)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(5)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(6)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(7)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(8)] public LS_LoopHeader LoopHeader { get; set; } = new();
	[SectionPosition(9)] public List<LN1> LN12 {get;set;} = new();
	[SectionPosition(10)] public LE_LoopTrailer LoopTrailer { get; set; } = new();

	//Summary
	[SectionPosition(11)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi820_PaymentOrderRemittanceAdvice>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForPaymentOrderRemittanceAdvice);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 100);
		validator.CollectionSize(x => x.ReferenceNumbers, 1, 5);
		validator.CollectionSize(x => x.DateTimeReference, 1, 10);
		

		validator.CollectionSize(x => x.LN1, 0, 200);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.LoopHeader);
		validator.Required(x => x.LoopTrailer);
		

		validator.CollectionSize(x => x.LN12, 1, 10000);
		foreach (var item in LN12) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
