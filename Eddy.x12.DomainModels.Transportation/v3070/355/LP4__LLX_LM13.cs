using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._355;

public class LP4__LLX_LM13 {
	[SectionPosition(1)] public M13_ManifestAmendmentDetails ManifestAmendmentDetails { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LM13>(this);
		validator.Required(x => x.ManifestAmendmentDetails);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
