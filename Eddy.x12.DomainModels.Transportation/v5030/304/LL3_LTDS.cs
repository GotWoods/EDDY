using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.DomainModels.Transportation.v5030._304;

public class LL3_LTDS {
	[SectionPosition(1)] public TDS_TotalMonetaryValueSummary TotalMonetaryValueSummary { get; set; } = new();
	[SectionPosition(2)] public CUR_Currency? Currency { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LL3_LTDS>(this);
		validator.Required(x => x.TotalMonetaryValueSummary);
		return validator.Results;
	}
}
