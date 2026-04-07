using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._820;

public class L7000__L7100__L7110__L7111__L71111_L711111 {
	[SectionPosition(1)] public AMT_MonetaryAmountInformation MonetaryAmountInformation { get; set; } = new();
	[SectionPosition(2)] public List<ADX_Adjustment> Adjustment { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L7000__L7100__L7110__L7111__L71111_L711111>(this);
		validator.Required(x => x.MonetaryAmountInformation);
		validator.CollectionSize(x => x.Adjustment, 1, 2147483647);
		return validator.Results;
	}
}
