using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._422;

public class LN1 {
	[SectionPosition(1)] public N1_Name PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public N3_AddressInformation? PartyLocation { get; set; }
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(5)] public List<N9_ReferenceIdentification> ExtendedReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 2);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 20);
		return validator.Results;
	}
}
