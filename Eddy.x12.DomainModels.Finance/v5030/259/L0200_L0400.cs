using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Finance.v5030._259;

public class L0200_L0400 {
	[SectionPosition(1)] public DTM_DateTimeReference DateTimeReference { get; set; } = new();
	[SectionPosition(2)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(3)] public INT_Interest? Interest { get; set; }
	[SectionPosition(4)] public List<AMT_MonetaryAmountInformation> MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(5)] public List<III_Information> Information { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0400>(this);
		validator.Required(x => x.DateTimeReference);
		validator.CollectionSize(x => x.QuantityInformation, 0, 2);
		validator.CollectionSize(x => x.MonetaryAmountInformation, 0, 2);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		return validator.Results;
	}
}
