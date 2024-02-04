using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.DomainModels.Transportation.v3040._355;

public class LP4__LLX__LVID__LN10__LH1_LH2 {
	[SectionPosition(1)] public H2_AdditionalHazardousMaterialDescription AdditionalHazardousMaterialDescription { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX__LVID__LN10__LH1_LH2>(this);
		validator.Required(x => x.AdditionalHazardousMaterialDescription);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
