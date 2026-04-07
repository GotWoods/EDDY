using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._155;

public class L20000__L23000__L23500_L23520 {
	[SectionPosition(1)] public CRC_ConditionsIndicator ConditionsIndicator { get; set; } = new();
	[SectionPosition(2)] public List<AWD_AmountWithDescription> AmountWithDescription { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000__L23000__L23500_L23520>(this);
		validator.Required(x => x.ConditionsIndicator);
		validator.CollectionSize(x => x.AmountWithDescription, 1, 2147483647);
		return validator.Results;
	}
}
