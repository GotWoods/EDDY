using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Transportation.v7060._286;

public class LSPI_LHL {
	[SectionPosition(1)] public HL_HierarchicalLevel HierarchicalLevel { get; set; } = new();
	[SectionPosition(2)] public List<LSPI__LHL_LLM> LLM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSPI_LHL>(this);
		validator.Required(x => x.HierarchicalLevel);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
