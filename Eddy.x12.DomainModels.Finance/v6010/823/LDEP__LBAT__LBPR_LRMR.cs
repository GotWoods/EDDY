using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.DomainModels.Finance.v6010._823;

public class LDEP__LBAT__LBPR_LRMR {
	[SectionPosition(1)] public RMR_RemittanceAdviceAccountsReceivableOpenItemReference RemittanceAdviceAccountsReceivableOpenItemReference { get; set; } = new();
	[SectionPosition(2)] public N1_PartyIdentification? PartyIdentification { get; set; }
	[SectionPosition(3)] public CUR_Currency? Currency { get; set; }
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(6)] public List<LDEP__LBAT__LBPR__LRMR_LIT1> LIT1 {get;set;} = new();
	[SectionPosition(7)] public List<LDEP__LBAT__LBPR__LRMR_LADX> LADX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDEP__LBAT__LBPR_LRMR>(this);
		validator.Required(x => x.RemittanceAdviceAccountsReceivableOpenItemReference);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.LIT1, 1, 2147483647);
		validator.CollectionSize(x => x.LADX, 1, 2147483647);
		foreach (var item in LIT1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LADX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
