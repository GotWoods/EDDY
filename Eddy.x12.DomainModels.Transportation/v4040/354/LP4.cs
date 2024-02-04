using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._354;

public class LP4 {
	[SectionPosition(1)] public P4_PortInformation PortInformation { get; set; } = new();
	[SectionPosition(2)] public X01_AutomatedManifestArchiveStatusDetails AutomatedManifestArchiveStatusDetails { get; set; } = new();
	[SectionPosition(3)] public List<X02_AutomatedManifestBillsEligibleOverdueArchiveDetails> AutomatedManifestBillsEligibleOverdueArchiveDetails { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4>(this);
		validator.Required(x => x.PortInformation);
		validator.Required(x => x.AutomatedManifestArchiveStatusDetails);
		validator.CollectionSize(x => x.AutomatedManifestBillsEligibleOverdueArchiveDetails, 0, 9999);
		return validator.Results;
	}
}
