using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;
using Eddy.x12.DomainModels.Finance.v5020._521;

namespace Eddy.x12.DomainModels.Finance.v5020;

public class Edi521_IncomeOrAssetOffset {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BGN_BeginningSegment BeginningSegment { get; set; } = new();
	[SectionPosition(3)] public BPR_BeginningSegmentForPaymentOrderRemittanceAdvice? BeginningSegmentForPaymentOrderRemittanceAdvice { get; set; }
	[SectionPosition(4)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(5)] public TRN_Trace? Trace { get; set; }
	[SectionPosition(6)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(7)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(8)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(9)] public List<AD1_AdjustmentAmount> AdjustmentAmount { get; set; } = new();
	[SectionPosition(10)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(11)] public List<LNM1> LNM1 {get;set;} = new();

	//Summary
	[SectionPosition(12)] public AMT_MonetaryAmountInformation? MonetaryAmountInformation { get; set; }
	[SectionPosition(13)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi521_IncomeOrAssetOffset>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegment);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.AdjustmentAmount, 1, 2147483647);
		

		validator.CollectionSize(x => x.LN1, 1, 2147483647);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LNM1, 1, 2147483647);
		foreach (var item in LNM1) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
