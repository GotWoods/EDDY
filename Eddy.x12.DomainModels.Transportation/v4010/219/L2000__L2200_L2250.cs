using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._219;

public class L2000__L2200_L2250 {
	[SectionPosition(1)] public LH1_HazardousIdentificationInformation HazardousIdentificationInformation { get; set; } = new();
	[SectionPosition(2)] public List<LH2_HazardousClassificationInformation> HazardousClassificationInformation { get; set; } = new();
	[SectionPosition(3)] public List<LH3_HazardousMaterialShippingName> HazardousMaterialShippingName { get; set; } = new();
	[SectionPosition(4)] public List<LFH_FreeformHazardousMaterialInformation> FreeformHazardousMaterialInformation { get; set; } = new();
	[SectionPosition(5)] public List<LEP_EPARequiredData> EPARequiredData { get; set; } = new();
	[SectionPosition(6)] public LH4_CanadianDangerousRequirements? CanadianDangerousRequirements { get; set; }
	[SectionPosition(7)] public List<LHT_TransborderHazardousRequirements> TransborderHazardousRequirements { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2200_L2250>(this);
		validator.Required(x => x.HazardousIdentificationInformation);
		validator.CollectionSize(x => x.HazardousClassificationInformation, 0, 5);
		validator.CollectionSize(x => x.HazardousMaterialShippingName, 0, 6);
		validator.CollectionSize(x => x.FreeformHazardousMaterialInformation, 0, 20);
		validator.CollectionSize(x => x.EPARequiredData, 0, 3);
		validator.CollectionSize(x => x.TransborderHazardousRequirements, 0, 3);
		return validator.Results;
	}
}
