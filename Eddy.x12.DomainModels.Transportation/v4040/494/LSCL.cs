using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._494;

public class LSCL {
	[SectionPosition(1)] public SCL_RateBasisScales RateBasisScales { get; set; } = new();
	[SectionPosition(2)] public List<RD_RateData> RateData { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSCL>(this);
		validator.Required(x => x.RateBasisScales);
		validator.CollectionSize(x => x.RateData, 0, 6);
		return validator.Results;
	}
}
