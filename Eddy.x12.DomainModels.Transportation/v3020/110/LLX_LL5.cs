using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._110;

public class LLX_LL5 {
	[SectionPosition(1)] public L5_DescriptionMarksAndNumbers DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(2)] public List<L0_LineItemQuantityAndWeight> LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(3)] public List<L10_Weight> Weight { get; set; } = new();
	[SectionPosition(4)] public List<LLX__LL5_LL1> LL1 {get;set;} = new();
	[SectionPosition(5)] public SL1_TariffReference? TariffReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LL5>(this);
		validator.Required(x => x.DescriptionMarksAndNumbers);
		validator.CollectionSize(x => x.LineItemQuantityAndWeight, 0, 10);
		validator.CollectionSize(x => x.Weight, 0, 30);
		validator.CollectionSize(x => x.LL1, 0, 30);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
