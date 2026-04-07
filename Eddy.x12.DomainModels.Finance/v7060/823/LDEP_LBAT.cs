using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Finance.v7060._823;

public class LDEP_LBAT {
	[SectionPosition(1)] public BAT_Batch Batch { get; set; } = new();
	[SectionPosition(2)] public List<AVA_FundsAvailability> FundsAvailability { get; set; } = new();
	[SectionPosition(3)] public AMT_MonetaryAmountInformation? MonetaryAmountInformation { get; set; }
	[SectionPosition(4)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(5)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(6)] public List<LDEP__LBAT_LBPR> LBPR {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LDEP_LBAT>(this);
		validator.Required(x => x.Batch);
		validator.CollectionSize(x => x.FundsAvailability, 0, 10);
		validator.CollectionSize(x => x.DateTimeReference, 0, 10);
		validator.CollectionSize(x => x.LBPR, 1, 2147483647);
		foreach (var item in LBPR) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
