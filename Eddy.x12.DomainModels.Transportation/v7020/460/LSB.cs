using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._460;

public class LSB {
	[SectionPosition(1)] public SB_DocketLevel DocketLevel { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public List<LSB_LSC> LSC {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSB>(this);
		validator.Required(x => x.DocketLevel);
		validator.CollectionSize(x => x.Geography, 0, 150);
		validator.CollectionSize(x => x.LSC, 1, 300);
		foreach (var item in LSC) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
