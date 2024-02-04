using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Transportation.v4060._417;

public class LN7__LREF_LN1 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7__LREF_LN1>(this);
		validator.Required(x => x.PartyIdentification);
		return validator.Results;
	}
}
