using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Transportation.v7010._312;

public class LLX_LL0 {
	[SectionPosition(1)] public L0_LineItemQuantityAndWeight LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(2)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(3)] public List<LLX__LL0_LL1> LL1 {get;set;} = new();
	[SectionPosition(4)] public L7_TariffReference? TariffReference { get; set; }
	[SectionPosition(5)] public List<LLX__LL0_LH1> LH1 {get;set;} = new();
	[SectionPosition(6)] public List<LLX__LL0_LLH1> LLH1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LL0>(this);
		validator.Required(x => x.LineItemQuantityAndWeight);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 0, 999);
		validator.CollectionSize(x => x.LL1, 0, 20);
		validator.CollectionSize(x => x.LH1, 0, 2);
		validator.CollectionSize(x => x.LLH1, 0, 100);
		foreach (var item in LL1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LH1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLH1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
