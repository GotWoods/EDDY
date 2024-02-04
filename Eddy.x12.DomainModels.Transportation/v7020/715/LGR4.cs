using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._715;

public class LGR4 {
	[SectionPosition(1)] public GR4_LoadingCluster LoadingCluster { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<LGR4_LN7> LN7 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LGR4>(this);
		validator.Required(x => x.LoadingCluster);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 5);
		validator.CollectionSize(x => x.LN7, 0, 9999);
		foreach (var item in LN7) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
