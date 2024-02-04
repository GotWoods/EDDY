using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._490;

public class L0300 {
	[SectionPosition(1)] public PT_Patron Patron { get; set; } = new();
	[SectionPosition(2)] public PRI_ExternalReferenceIdentifier? ExternalReferenceIdentifier { get; set; }
	[SectionPosition(3)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300>(this);
		validator.Required(x => x.Patron);
		return validator.Results;
	}
}
