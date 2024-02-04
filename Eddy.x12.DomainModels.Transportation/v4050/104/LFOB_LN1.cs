using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._104;

public class LFOB_LN1 {
	[SectionPosition(1)] public N1_Name PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(3)] public N3_AddressInformation? PartyLocation { get; set; }
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<N9_ReferenceIdentification> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LFOB_LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 10);
		return validator.Results;
	}
}
