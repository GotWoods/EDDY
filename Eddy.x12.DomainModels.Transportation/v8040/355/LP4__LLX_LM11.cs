using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._355;

public class LP4__LLX_LM11 {
	[SectionPosition(1)] public M11_ManifestBillOfLadingDetails ManifestBillOfLadingDetails { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4__LLX_LM11>(this);
		validator.Required(x => x.ManifestBillOfLadingDetails);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
