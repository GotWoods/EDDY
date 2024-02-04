using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Transportation.v5050._404;

public class LN7__LREF_LN1 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(5)] public List<BL_BillingInformation> BillingInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7__LREF_LN1>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 2);
		validator.CollectionSize(x => x.BillingInformation, 0, 12);
		return validator.Results;
	}
}
