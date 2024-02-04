using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._433;

public class LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public PI_PriceAuthorityIdentification? PriceAuthorityIdentification { get; set; }
	[SectionPosition(3)] public List<CD_ShipmentConditions> ShipmentConditions { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.ShipmentConditions, 0, 50);
		return validator.Results;
	}
}
