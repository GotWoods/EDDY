using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Transportation.v4030._104;

public class LFOB_LN1 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(3)] public N3_AddressInformation? AddressInformation { get; set; }
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(6)] public PER_AdministrativeCommunicationsContact? AdministrativeCommunicationsContact { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LFOB_LN1>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 10);
		return validator.Results;
	}
}
