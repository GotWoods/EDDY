using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Finance.v8030._820;

public class L5000__L5100_L5110 {
	[SectionPosition(1)] public AIN_Income Income { get; set; } = new();
	[SectionPosition(2)] public List<QTY_QuantityInformation> QuantityInformation { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L5000__L5100_L5110>(this);
		validator.Required(x => x.Income);
		validator.CollectionSize(x => x.QuantityInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		return validator.Results;
	}
}
