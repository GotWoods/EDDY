using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Finance.v3070._823;

public class LDEP {
	[SectionPosition(1)] public DEP_Deposit Deposit { get; set; } = new();
	[SectionPosition(2)] public AMT_MonetaryAmount MonetaryAmount { get; set; } = new();
	[SectionPosition(3)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(4)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(5)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(6)] public List<LDEP_LBAT> LBAT {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDEP>(this);
		validator.Required(x => x.Deposit);
		validator.Required(x => x.MonetaryAmount);
		validator.CollectionSize(x => x.Quantity, 1, 2);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 5);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.LBAT, 1, 2147483647);
		foreach (var item in LBAT) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
