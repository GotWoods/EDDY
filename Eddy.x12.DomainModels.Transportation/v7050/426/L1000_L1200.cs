using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Transportation.v7050._426;

public class L1000_L1200 {
	[SectionPosition(1)] public N1_PartyIdentification PartyIdentification { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(6)] public List<BL_BillingInformation> BillingInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L1000_L1200>(this);
		validator.Required(x => x.PartyIdentification);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 3);
		validator.CollectionSize(x => x.BillingInformation, 0, 12);
		return validator.Results;
	}
}
