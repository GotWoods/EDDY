using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;
using Eddy.x12.DomainModels.Finance.v3020._849;

namespace Eddy.x12.DomainModels.Finance.v3020;

public class Edi849_ResponseToProductTransferAccountAdjustment {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BRC_BeginningSegmentResponseToProductTransferAccountAdjustment BeginningSegmentResponseToProductTransferAccountAdjustment { get; set; } = new();
	[SectionPosition(3)] public List<AAA_RequestValidation> RequestValidation { get; set; } = new();
	[SectionPosition(4)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(5)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(7)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(8)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(9)] public List<LCON> LCON {get;set;} = new();

	//Summary
	[SectionPosition(10)] public CTT_TransactionTotals TransactionTotals { get; set; } = new();
	[SectionPosition(11)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(12)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi849_ResponseToProductTransferAccountAdjustment>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentResponseToProductTransferAccountAdjustment);
		validator.CollectionSize(x => x.RequestValidation, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 12);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		

		validator.CollectionSize(x => x.LN1, 0, 50);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LCON, 0, 10000);
		foreach (var item in LCON) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionTotals);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 5);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
