using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._490;

public class LPT {
	[SectionPosition(1)] public PT_Patron Patron { get; set; } = new();
	[SectionPosition(2)] public PRI_ExternalReferenceIdentifier? ExternalReferenceIdentifier { get; set; }
	[SectionPosition(3)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPT>(this);
		validator.Required(x => x.Patron);
		return validator.Results;
	}
}
