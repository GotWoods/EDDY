using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Transportation.v7030._859;

public class LLX_LH1 {
	[SectionPosition(1)] public H1_HazardousMaterial HazardousMaterial { get; set; } = new();
	[SectionPosition(2)] public List<H2_AdditionalHazardousMaterialDescription> AdditionalHazardousMaterialDescription { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LH1>(this);
		validator.Required(x => x.HazardousMaterial);
		validator.CollectionSize(x => x.AdditionalHazardousMaterialDescription, 0, 2);
		return validator.Results;
	}
}
