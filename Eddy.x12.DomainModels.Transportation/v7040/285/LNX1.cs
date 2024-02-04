using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Transportation.v7040._285;

public class LNX1 {
	[SectionPosition(1)] public NX1_PropertyOrEntityIdentification PropertyOrEntityIdentification { get; set; } = new();
	[SectionPosition(2)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<LNX1_LLM> LLM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNX1>(this);
		validator.Required(x => x.PropertyOrEntityIdentification);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.LLM, 1, 2147483647);
		foreach (var item in LLM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
