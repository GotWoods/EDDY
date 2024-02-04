using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Transportation.v8010._104;

public class LFOB_LL5 {
	[SectionPosition(1)] public L5_DescriptionMarksAndNumbers DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(2)] public List<L0_LineItemQuantityAndWeight> LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(3)] public List<L1_RateAndCharges> RateAndCharges { get; set; } = new();
	[SectionPosition(4)] public List<L4_Measurement> Measurement { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LFOB_LL5>(this);
		validator.Required(x => x.DescriptionMarksAndNumbers);
		validator.CollectionSize(x => x.LineItemQuantityAndWeight, 0, 10);
		validator.CollectionSize(x => x.RateAndCharges, 0, 10);
		validator.CollectionSize(x => x.Measurement, 0, 10);
		return validator.Results;
	}
}
