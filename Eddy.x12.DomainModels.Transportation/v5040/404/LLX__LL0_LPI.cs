using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.DomainModels.Transportation.v5040._404;

public class LLX__LL0_LPI {
	[SectionPosition(1)] public PI_PriceAuthorityIdentification PriceAuthorityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<CD_ShipmentConditions> ShipmentConditions { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LL0_LPI>(this);
		validator.Required(x => x.PriceAuthorityIdentification);
		validator.CollectionSize(x => x.ShipmentConditions, 0, 10);
		return validator.Results;
	}
}
