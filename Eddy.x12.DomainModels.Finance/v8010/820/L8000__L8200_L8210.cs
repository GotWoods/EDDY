using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._820;

public class L8000__L8200_L8210 {
	[SectionPosition(1)] public RMR_RemittanceAdviceAccountsReceivableOpenItemReference RemittanceAdviceAccountsReceivableOpenItemReference { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(4)] public List<L8000__L8200__L8210_L8211> L8211 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L8000__L8200_L8210>(this);
		validator.Required(x => x.RemittanceAdviceAccountsReceivableOpenItemReference);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.L8211, 1, 2147483647);
		foreach (var item in L8211) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
