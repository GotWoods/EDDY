using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._490;

public class LPT {
	[SectionPosition(1)] public PT_Patron Patron { get; set; } = new();
	[SectionPosition(2)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPT>(this);
		validator.Required(x => x.Patron);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 2);
		return validator.Results;
	}
}
