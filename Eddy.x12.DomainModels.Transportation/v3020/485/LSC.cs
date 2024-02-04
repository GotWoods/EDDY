using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._485;

public class LSC {
	[SectionPosition(1)] public SC_DocketSubLevel DocketSubLevel { get; set; } = new();
	[SectionPosition(2)] public List<LSC_LRA> LRA {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSC>(this);
		validator.Required(x => x.DocketSubLevel);
		validator.CollectionSize(x => x.LRA, 0, 10);
		foreach (var item in LRA) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
