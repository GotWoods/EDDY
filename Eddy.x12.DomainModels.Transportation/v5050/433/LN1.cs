using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Transportation.v5050._433;

public class LN1 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public PI_PriceAuthorityIdentification? PriceAuthorityIdentification { get; set; }
	[SectionPosition(3)] public List<CD_ShipmentConditions> ShipmentConditions { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.ShipmentConditions, 0, 50);
		return validator.Results;
	}
}
