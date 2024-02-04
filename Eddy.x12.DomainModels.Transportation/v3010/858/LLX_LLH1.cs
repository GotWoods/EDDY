using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.DomainModels.Transportation.v3010._858;

public class LLX_LLH1 {
	[SectionPosition(1)] public LH1_HazardousIdentificationInformation HazardousIdentificationInformation { get; set; } = new();
	[SectionPosition(2)] public List<LH2_HazardousClassificationInformation> HazardousClassificationInformation { get; set; } = new();
	[SectionPosition(3)] public List<LH3_HazardousMaterialShippingName> HazardousMaterialShippingName { get; set; } = new();
	[SectionPosition(4)] public LH4_CanadianDangerousRequirements? CanadianDangerousRequirements { get; set; }
	[SectionPosition(5)] public List<LHR_HazardousMaterialIdentifyingReferenceNumbers> HazardousMaterialIdentifyingReferenceNumbers { get; set; } = new();
	[SectionPosition(6)] public LHE_EmptyEquipmentHazardousMaterialInformation? EmptyEquipmentHazardousMaterialInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LLH1>(this);
		validator.Required(x => x.HazardousIdentificationInformation);
		validator.CollectionSize(x => x.HazardousClassificationInformation, 0, 2);
		validator.CollectionSize(x => x.HazardousMaterialShippingName, 0, 10);
		validator.CollectionSize(x => x.HazardousMaterialIdentifyingReferenceNumbers, 0, 10);
		return validator.Results;
	}
}
