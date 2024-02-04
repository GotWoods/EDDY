using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._410;

public class LLX_LL0 {
	[SectionPosition(1)] public L0_LineItemQuantityAndWeight LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(3)] public List<LLX__LL0_LL1> LL1 {get;set;} = new();
	[SectionPosition(4)] public List<LLX__LL0_LPI> LPI {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LL0>(this);
		validator.Required(x => x.LineItemQuantityAndWeight);
		validator.CollectionSize(x => x.Measurements, 0, 3);
		validator.CollectionSize(x => x.LL1, 1, 10);
		validator.CollectionSize(x => x.LPI, 0, 30);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
