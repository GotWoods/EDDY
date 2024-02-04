using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._301;

public class LLX_LH1 {
	[SectionPosition(1)] public H1_HazardousMaterial HazardousMaterial { get; set; } = new();
	[SectionPosition(2)] public H2_AdditionalHazardousMaterialDescription? AdditionalHazardousMaterialDescription { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LH1>(this);
		validator.Required(x => x.HazardousMaterial);
		return validator.Results;
	}
}
