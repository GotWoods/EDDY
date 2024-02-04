using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Transportation.v3040._426;

public class L1000_L1200 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public List<N3_AddressInformation> AddressInformation { get; set; } = new();
	[SectionPosition(3)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(4)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(5)] public BL_BillingInformation? BillingInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L1000_L1200>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.AddressInformation, 0, 2);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 2);
		return validator.Results;
	}
}
