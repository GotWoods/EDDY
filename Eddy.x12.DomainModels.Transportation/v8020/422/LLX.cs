using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Transportation.v8020._422;

public class LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public D9_DestinationStation? DestinationStation { get; set; }
	[SectionPosition(3)] public List<LLX_LF9> LF9 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.LF9, 1, 31);
		foreach (var item in LF9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
