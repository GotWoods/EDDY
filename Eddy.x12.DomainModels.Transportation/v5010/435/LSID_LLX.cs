using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Transportation.v5010._435;

public class LSID_LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<LH3_HazardousMaterialShippingNameInformation> HazardousMaterialShippingNameInformation { get; set; } = new();
	[SectionPosition(4)] public List<LH2_HazardousClassificationInformation> HazardousClassificationInformation { get; set; } = new();
	[SectionPosition(5)] public List<LFH_FreeFormHazardousMaterialInformation> FreeFormHazardousMaterialInformation { get; set; } = new();
	[SectionPosition(6)] public List<LEP_EPARequiredData> EPARequiredData { get; set; } = new();
	[SectionPosition(7)] public List<LH4_CanadianDangerousRequirements> CanadianDangerousRequirements { get; set; } = new();
	[SectionPosition(8)] public List<CRC_ConditionsIndicator> ConditionsIndicator { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSID_LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 0, 50);
		validator.CollectionSize(x => x.HazardousMaterialShippingNameInformation, 0, 100);
		validator.CollectionSize(x => x.HazardousClassificationInformation, 0, 8);
		validator.CollectionSize(x => x.FreeFormHazardousMaterialInformation, 0, 20);
		validator.CollectionSize(x => x.EPARequiredData, 0, 3);
		validator.CollectionSize(x => x.CanadianDangerousRequirements, 0, 4);
		validator.CollectionSize(x => x.ConditionsIndicator, 0, 5);
		return validator.Results;
	}
}
