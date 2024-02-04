using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Transportation.v8020._355;

public class LVEH_LM7 {
	[SectionPosition(1)] public M7_SealNumbers SealNumbers { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LVEH_LM7>(this);
		validator.Required(x => x.SealNumbers);
		validator.CollectionSize(x => x.Remarks, 0, 10);
		return validator.Results;
	}
}
