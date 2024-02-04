using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050._325;

public class LMBL__LLIN_LH1 {
	[SectionPosition(1)] public H1_HazardousMaterial HazardousMaterial { get; set; } = new();
	[SectionPosition(2)] public List<H2_AdditionalHazardousMaterialDescription> AdditionalHazardousMaterialDescription { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LMBL__LLIN_LH1>(this);
		validator.Required(x => x.HazardousMaterial);
		validator.CollectionSize(x => x.AdditionalHazardousMaterialDescription, 0, 10);
		return validator.Results;
	}
}
