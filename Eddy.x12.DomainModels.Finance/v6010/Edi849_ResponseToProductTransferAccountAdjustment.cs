using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;
using Eddy.x12.DomainModels.Finance.v6010._849;

namespace Eddy.x12.DomainModels.Finance.v6010;

public class Edi849_ResponseToProductTransferAccountAdjustment {
	[SectionPosition(1)] public ST_TransactionSetHeader TransactionSetHeader { get; set; } = new();
	[SectionPosition(2)] public BRC_BeginningSegmentForResponseToProductTransferAccountAdjustment BeginningSegmentForResponseToProductTransferAccountAdjustment { get; set; } = new();
	[SectionPosition(3)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(4)] public List<AAA_RequestValidation> RequestValidation { get; set; } = new();
	[SectionPosition(5)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(6)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(8)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(9)] public List<LN1> LN1 {get;set;} = new();

	//Details
	[SectionPosition(10)] public List<LCON> LCON {get;set;} = new();

	//Summary
	[SectionPosition(11)] public CTT_TransactionTotals TransactionTotals { get; set; } = new();
	[SectionPosition(12)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(13)] public SE_TransactionSetTrailer TransactionSetTrailer { get; set; } = new();


	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<Edi849_ResponseToProductTransferAccountAdjustment>(this);
		validator.Required(x => x.TransactionSetHeader);
		validator.Required(x => x.BeginningSegmentForResponseToProductTransferAccountAdjustment);
		validator.CollectionSize(x => x.RequestValidation, 0, 10);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 0, 10);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 12);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		

		validator.CollectionSize(x => x.LN1, 0, 50);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		

		validator.CollectionSize(x => x.LCON, 0, 10000);
		foreach (var item in LCON) validator.Results.AddRange(item.Validate().Errors);
		validator.Required(x => x.TransactionTotals);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 5);
		validator.Required(x => x.TransactionSetTrailer);
		return validator.Results;
	}
}
