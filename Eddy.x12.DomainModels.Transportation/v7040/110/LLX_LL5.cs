using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Transportation.v7040._110;

public class LLX_LL5 {
	[SectionPosition(1)] public L5_DescriptionMarksAndNumbers DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(2)] public L0_LineItemQuantityAndWeight? LineItemQuantityAndWeight { get; set; }
	[SectionPosition(3)] public List<L4_Measurement> Measurement { get; set; } = new();
	[SectionPosition(4)] public List<L10_WeightInformation> WeightInformation { get; set; } = new();
	[SectionPosition(5)] public SL1_TariffDetails? TariffDetails { get; set; }
	[SectionPosition(6)] public List<LLX__LL5_LL1> LL1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LL5>(this);
		validator.Required(x => x.DescriptionMarksAndNumbers);
		validator.CollectionSize(x => x.Measurement, 0, 4);
		validator.CollectionSize(x => x.WeightInformation, 0, 4);
		validator.CollectionSize(x => x.LL1, 0, 30);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
