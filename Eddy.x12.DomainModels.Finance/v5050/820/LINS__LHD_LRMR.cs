using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Finance.v5050._820;

public class LINS__LHD_LRMR {
	[SectionPosition(1)] public RMR_RemittanceAdviceAccountsReceivableOpenItemReference RemittanceAdviceAccountsReceivableOpenItemReference { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<LINS__LHD__LRMR_LADX> LADX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LINS__LHD_LRMR>(this);
		validator.Required(x => x.RemittanceAdviceAccountsReceivableOpenItemReference);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.LADX, 1, 2147483647);
		foreach (var item in LADX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
