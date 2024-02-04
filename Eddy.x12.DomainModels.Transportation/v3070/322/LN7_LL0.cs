using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._322;

public class LN7_LL0 {
	[SectionPosition(1)] public L0_LineItemQuantityAndWeight LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(2)] public L5_DescriptionMarksAndNumbers? DescriptionMarksAndNumbers { get; set; }
	[SectionPosition(3)] public List<H1_HazardousMaterial> HazardousMaterial { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LN7_LL0>(this);
		validator.Required(x => x.LineItemQuantityAndWeight);
		validator.CollectionSize(x => x.HazardousMaterial, 0, 3);
		return validator.Results;
	}
}
