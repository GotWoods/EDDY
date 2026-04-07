using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._880;

public class L0400_L0410 {
	[SectionPosition(1)] public REF_ReferenceInformation ReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	[SectionPosition(3)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(4)] public G72_AllowanceOrCharge? AllowanceOrCharge { get; set; }
	[SectionPosition(5)] public List<L0400__L0410_L0411> L0411 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400_L0410>(this);
		validator.Required(x => x.ReferenceInformation);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 2);
		validator.CollectionSize(x => x.L0411, 1, 2147483647);
		foreach (var item in L0411) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
