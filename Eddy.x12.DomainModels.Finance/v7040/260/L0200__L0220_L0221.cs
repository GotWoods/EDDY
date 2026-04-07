using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Finance.v7040._260;

public class L0200__L0220_L0221 {
	[SectionPosition(1)] public FCL_Foreclosure Foreclosure { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200__L0220_L0221>(this);
		validator.Required(x => x.Foreclosure);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 5);
		return validator.Results;
	}
}
