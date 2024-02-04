using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Transportation.v6030._120;

public class LG62 {
	[SectionPosition(1)] public G62_DateTime DateTime { get; set; } = new();
	[SectionPosition(2)] public List<LG62_LVC> LVC {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LG62>(this);
		validator.Required(x => x.DateTime);
		validator.CollectionSize(x => x.LVC, 1, 999);
		foreach (var item in LVC) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
