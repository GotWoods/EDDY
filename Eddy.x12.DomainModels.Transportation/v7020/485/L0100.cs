using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._485;

public class L0100 {
	[SectionPosition(1)] public SC_DocketSubLevel DocketSubLevel { get; set; } = new();
	[SectionPosition(2)] public List<L0100_L0110> L0110 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0100>(this);
		validator.Required(x => x.DocketSubLevel);
		validator.CollectionSize(x => x.L0110, 0, 10);
		foreach (var item in L0110) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
