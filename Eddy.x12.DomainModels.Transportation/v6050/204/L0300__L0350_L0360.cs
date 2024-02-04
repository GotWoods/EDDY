using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.DomainModels.Transportation.v6050._204;

public class L0300__L0350_L0360 {
	[SectionPosition(1)] public L5_DescriptionMarksAndNumbers DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(2)] public AT8_ShipmentWeightPackagingAndQuantityData? ShipmentWeightPackagingAndQuantityData { get; set; }
	[SectionPosition(3)] public L4_Measurement? Measurement { get; set; }
	[SectionPosition(4)] public List<L0300__L0350__L0360_L0365> L0365 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300__L0350_L0360>(this);
		validator.Required(x => x.DescriptionMarksAndNumbers);
		validator.CollectionSize(x => x.L0365, 0, 99);
		foreach (var item in L0365) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
