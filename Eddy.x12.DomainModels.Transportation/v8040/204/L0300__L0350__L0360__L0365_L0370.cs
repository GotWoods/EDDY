using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._204;

public class L0300__L0350__L0360__L0365_L0370 {
	[SectionPosition(1)] public LH1_HazardousIdentificationInformation HazardousIdentificationInformation { get; set; } = new();
	[SectionPosition(2)] public List<LH2_HazardousClassificationInformation> HazardousClassificationInformation { get; set; } = new();
	[SectionPosition(3)] public List<LH3_HazardousMaterialShippingNameInformation> HazardousMaterialShippingNameInformation { get; set; } = new();
	[SectionPosition(4)] public List<LFH_FreeFormHazardousMaterialInformation> FreeFormHazardousMaterialInformation { get; set; } = new();
	[SectionPosition(5)] public List<LEP_EPARequiredData> EPARequiredData { get; set; } = new();
	[SectionPosition(6)] public LH4_CanadianDangerousRequirements? CanadianDangerousRequirements { get; set; }
	[SectionPosition(7)] public List<LHT_TransborderHazardousRequirements> TransborderHazardousRequirements { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300__L0350__L0360__L0365_L0370>(this);
		validator.Required(x => x.HazardousIdentificationInformation);
		validator.CollectionSize(x => x.HazardousClassificationInformation, 0, 4);
		validator.CollectionSize(x => x.HazardousMaterialShippingNameInformation, 0, 10);
		validator.CollectionSize(x => x.FreeFormHazardousMaterialInformation, 0, 30);
		validator.CollectionSize(x => x.EPARequiredData, 0, 3);
		validator.CollectionSize(x => x.TransborderHazardousRequirements, 0, 3);
		return validator.Results;
	}
}
