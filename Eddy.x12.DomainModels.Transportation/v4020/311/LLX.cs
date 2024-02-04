using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._311;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<Y2_ContainerDetails> ContainerDetails { get; set; } = new();
	[SectionPosition(3)] public List<LLX_LED> LED {get;set;} = new();
	[SectionPosition(4)] public List<LLX_LL0> LL0 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.ContainerDetails, 0, 10);
		validator.CollectionSize(x => x.LED, 0, 999);
		validator.CollectionSize(x => x.LL0, 0, 120);
		foreach (var item in LED) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LL0) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
