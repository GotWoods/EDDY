using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Transportation.v6030._858;

public class LHL_LLH1 {
	[SectionPosition(1)] public LH1_HazardousIdentificationInformation HazardousIdentificationInformation { get; set; } = new();
	[SectionPosition(2)] public List<LH2_HazardousClassificationInformation> HazardousClassificationInformation { get; set; } = new();
	[SectionPosition(3)] public List<LH3_HazardousMaterialShippingNameInformation> HazardousMaterialShippingNameInformation { get; set; } = new();
	[SectionPosition(4)] public List<LFH_FreeFormHazardousMaterialInformation> FreeFormHazardousMaterialInformation { get; set; } = new();
	[SectionPosition(5)] public List<LEP_EPARequiredData> EPARequiredData { get; set; } = new();
	[SectionPosition(6)] public List<LH4_CanadianDangerousRequirements> CanadianDangerousRequirements { get; set; } = new();
	[SectionPosition(7)] public List<LHT_TransborderHazardousRequirements> TransborderHazardousRequirements { get; set; } = new();
	[SectionPosition(8)] public List<LHR_HazardousMaterialIdentifyingReferenceNumbers> HazardousMaterialIdentifyingReferenceNumbers { get; set; } = new();
	[SectionPosition(9)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(10)] public LHE_EmptyEquipmentHazardousMaterialInformation? EmptyEquipmentHazardousMaterialInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LLH1>(this);
		validator.Required(x => x.HazardousIdentificationInformation);
		validator.CollectionSize(x => x.HazardousClassificationInformation, 0, 4);
		validator.CollectionSize(x => x.HazardousMaterialShippingNameInformation, 0, 12);
		validator.CollectionSize(x => x.FreeFormHazardousMaterialInformation, 0, 20);
		validator.CollectionSize(x => x.EPARequiredData, 0, 3);
		validator.CollectionSize(x => x.CanadianDangerousRequirements, 0, 4);
		validator.CollectionSize(x => x.TransborderHazardousRequirements, 0, 3);
		validator.CollectionSize(x => x.HazardousMaterialIdentifyingReferenceNumbers, 0, 10);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 0, 5);
		return validator.Results;
	}
}