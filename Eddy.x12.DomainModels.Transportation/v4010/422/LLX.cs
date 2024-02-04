using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._422;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(3)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(4)] public List<LLX_LF9> LF9 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.DateTime, 1, 2);
		validator.CollectionSize(x => x.LF9, 1, 31);
		foreach (var item in LF9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
