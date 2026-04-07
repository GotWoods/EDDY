using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Finance.v3030._820;

public class LENT_LRMR {
	[SectionPosition(1)] public RMR_RemittanceAdviceAccountsReceivableOpenItemReference RemittanceAdviceAccountsReceivableOpenItemReference { get; set; } = new();
	[SectionPosition(2)] public List<NTE_NoteSpecialInstruction> NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(4)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(5)] public List<LENT__LRMR_LIT1> LIT1 {get;set;} = new();
	[SectionPosition(6)] public List<LENT__LRMR_LADX> LADX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LENT_LRMR>(this);
		validator.Required(x => x.RemittanceAdviceAccountsReceivableOpenItemReference);
		validator.CollectionSize(x => x.NoteSpecialInstruction, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceNumbers, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.LIT1, 1, 2147483647);
		validator.CollectionSize(x => x.LADX, 1, 2147483647);
		foreach (var item in LIT1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LADX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
